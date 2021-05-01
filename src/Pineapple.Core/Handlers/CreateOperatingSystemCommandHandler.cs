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
    public class CreateOperatingSystemCommandHandler : RequestHandler<CreateOperatingSystemCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateOperatingSystemCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateOperatingSystemCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var existingOperatingSystem = await databaseContext
                .OperatingSystems
                .FirstOrDefaultAsync(operatingSystem => operatingSystem.Symbol == request.Symbol)
                .ConfigureAwait(false);

            if (!(existingOperatingSystem is null))
            {
                throw new OperatingSystemAlreadyExistsException($"OperatingSystem {existingOperatingSystem.Symbol} already exists");
            }

            var operatingSystemId = Guid.NewGuid();

            var operatingSystem = Domain.Entities.OperatingSystem.Create(operatingSystemId, request.Name, request.Symbol, request.Description);

            await databaseContext.OperatingSystems.AddAsync(operatingSystem).ConfigureAwait(false);

            var operatingSystemLogId = Guid.NewGuid();

            var operatingSystemLog = Domain.Entities.OperatingSystemLog.Create(operatingSystemLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), operatingSystemId); // Mock!

            await databaseContext.Logs.AddAsync(operatingSystemLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return operatingSystemId;
        }
    }
}
