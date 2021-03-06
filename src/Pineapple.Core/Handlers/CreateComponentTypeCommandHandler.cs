using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

namespace Pineapple.Core.Handler
{
    public class CreateComponentTypeCommandHandler : RequestHandler<CreateComponentTypeCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateComponentTypeCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateComponentTypeCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var existingComponentType = await databaseContext
                .ComponentTypes
                .FirstOrDefaultAsync(componentType => componentType.Symbol == request.Symbol)
                .ConfigureAwait(false);

            if (!(existingComponentType is null))
            {
                throw new ComponentTypeAlreadyExistsException($"ComponentType {existingComponentType.Symbol} already exists");
            }

            var componentTypeId = Guid.NewGuid();

            var componentType = Domain.Entities.ComponentType.Create(componentTypeId, request.Name, request.Symbol, request.Description);

            await databaseContext.ComponentTypes.AddAsync(componentType).ConfigureAwait(false);

            var componentTypeLogId = Guid.NewGuid();

            var componentTypeLog = Domain.Entities.ComponentTypeLog.Create(componentTypeLogId, AvailableLogCategories.CreateEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), componentTypeId); // Mock!

            await databaseContext.Logs.AddAsync(componentTypeLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return componentTypeId;
        }
    }
}
