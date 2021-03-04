using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
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

            var componentVersion = new Domain.Entities.ComponentVersion()
            {
                Id = componentVersionId,
                ModifiedDate = DateTime.Now,
                Major = request.Major,
                Minor = request.Minor,
                Patch = request.Patch,
                PreRelease = request.PreRelease,
                Description = request.Description,
                ComponentId = request.ComponentId
            };

            await databaseContext.ComponentVersions.AddAsync(componentVersion).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return componentVersionId;
        }
    }
}
