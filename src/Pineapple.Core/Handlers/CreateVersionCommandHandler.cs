using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateVersionCommandHandler : RequestHandler<CreateVersionCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateVersionCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateVersionCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var versionId = Guid.NewGuid();

            var version = new Domain.Entities.Version()
            {
                Id = versionId,
                ModifiedDate = DateTime.Now,
                Major = request.Major,
                Minor = request.Minor,
                Patch = request.Patch,
                PreRelease = request.PreRelease,
                Description = request.Description,
                ComponentId = request.ComponentId
            };

            await databaseContext.Versions.AddAsync(version).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return versionId;
        }
    }
}
