using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateComponentVersionCommandHandler : RequestHandler<CreateComponentVersionCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateComponentVersionCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateComponentVersionCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentVersionId = Guid.NewGuid();

            var componentVersion = Domain.Entities.ComponentVersion.Create(componentVersionId, request.Major, request.Minor, request.Patch, request.PreRelease, request.Description, request.ComponentId);

            await databaseContext.ComponentVersions.AddAsync(componentVersion).ConfigureAwait(false);

            var componentVersionLogId = Guid.NewGuid();

            var componentVersionLog = Domain.Entities.ComponentVersionLog.Create(componentVersionLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), componentVersionId); // Mock!

            await databaseContext.Logs.AddAsync(componentVersionLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return componentVersionId;
        }
    }
}
