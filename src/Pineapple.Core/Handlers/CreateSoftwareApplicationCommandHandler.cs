using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateSoftwareApplicationCommandHandler : RequestHandler<CreateSoftwareApplicationCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateSoftwareApplicationCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var softwareApplicationId = Guid.NewGuid();

            var softwareApplication = Domain.Entities.SoftwareApplication.Create(softwareApplicationId, request.Name, request.Symbol, request.Description);

            await databaseContext.SoftwareApplications.AddAsync(softwareApplication).ConfigureAwait(false);

            var softwareApplicationLogId = Guid.NewGuid();

            var softwareApplicationLog = Domain.Entities.SoftwareApplicationLog.Create(softwareApplicationLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), softwareApplicationId); // Mock!

            await databaseContext.Logs.AddAsync(softwareApplicationLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return softwareApplicationId;
        }
    }
}
