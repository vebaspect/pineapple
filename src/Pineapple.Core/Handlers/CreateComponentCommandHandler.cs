using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateComponentCommandHandler : RequestHandler<CreateComponentCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateComponentCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentId = Guid.NewGuid();

            var component = Domain.Entities.Component.Create(componentId, request.Name, request.SourceCodeRepositoryUrl, request.PackagesRepositoryPath, request.LicensesRepositoryPath, request.Description, request.ProductId, request.ComponentTypeId);

            await databaseContext.Components.AddAsync(component).ConfigureAwait(false);

            var componentLogId = Guid.NewGuid();

            var componentLog = Domain.Entities.ComponentLog.Create(componentLogId, AvailableLogCategories.CreateEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), componentId); // Mock!

            await databaseContext.Logs.AddAsync(componentLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return componentId;
        }
    }
}
