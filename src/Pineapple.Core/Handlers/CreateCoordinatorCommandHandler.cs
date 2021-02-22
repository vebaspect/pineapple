using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateCoordinatorCommandHandler : RequestHandler<CreateCoordinatorCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateCoordinatorCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateCoordinatorCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var coordinatorId = Guid.NewGuid();

            var coordinator = new Domain.Entities.Coordinator()
            {
                Id = coordinatorId,
                ModifiedDate = DateTime.UtcNow,
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email,
                ImplementationId = request.ImplementationId,
            };

            await databaseContext.Coordinators.AddAsync(coordinator).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return coordinatorId;
        }
    }
}
