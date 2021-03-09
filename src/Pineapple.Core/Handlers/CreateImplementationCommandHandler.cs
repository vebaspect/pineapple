using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class CreateImplementationCommandHandler : RequestHandler<CreateImplementationCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateImplementationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateImplementationCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementationId = Guid.NewGuid();

            var implementation = Domain.Entities.Implementation.Create(implementationId, request.Name, request.Description);

            await databaseContext.Implementations.AddAsync(implementation).ConfigureAwait(false);

            var implementationLogId = Guid.NewGuid();

            var implementationLog = Domain.Entities.ImplementationLog.Create(implementationLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), implementationId); // Mock!

            await databaseContext.Logs.AddAsync(implementationLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return implementationId;
        }
    }
}
