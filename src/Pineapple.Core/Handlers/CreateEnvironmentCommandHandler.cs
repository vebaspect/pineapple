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

            var existingEnvironment = await databaseContext
                .Environments
                .FirstOrDefaultAsync(environment => environment.Symbol == request.Symbol)
                .ConfigureAwait(false);

            if (!(existingEnvironment is null))
            {
                throw new EnvironmentAlreadyExistsException($"Environment {existingEnvironment.Symbol} already exists");
            }

            var environmentId = Guid.NewGuid();

            var environment = Domain.Entities.Environment.Create(environmentId, request.Name, request.Symbol, request.Description, request.ImplementationId, request.OperatorId);

            await databaseContext.Environments.AddAsync(environment).ConfigureAwait(false);

            var environmentLogId = Guid.NewGuid();

            var environmentLog = Domain.Entities.EnvironmentLog.Create(environmentLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), environmentId); // Mock!

            await databaseContext.Logs.AddAsync(environmentLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return environmentId;
        }
    }
}
