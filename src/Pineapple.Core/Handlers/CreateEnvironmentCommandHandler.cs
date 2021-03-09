using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateEnvironmentCommandHandler : RequestHandler<CreateEnvironmentCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateEnvironmentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateEnvironmentCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var environmentId = Guid.NewGuid();

            var environment = Domain.Entities.Environment.Create(environmentId, request.Name, request.Symbol, request.Description, request.ImplementationId, request.OperatorId);

            await databaseContext.Environments.AddAsync(environment).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return environmentId;
        }
    }
}
