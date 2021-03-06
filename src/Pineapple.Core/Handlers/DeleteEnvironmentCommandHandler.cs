using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class DeleteEnvironmentCommandHandler : AsyncRequestHandler<DeleteEnvironmentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteEnvironmentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteEnvironmentCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new ImplementationNotFoundException($"Implementation {request.ImplementationId} has not been found");
            }

            var environment = implementation
                .Environments?
                .FirstOrDefault(environment => environment.Id == request.EnvironmentId);

            if (environment is null)
            {
                throw new EnvironmentNotFoundException($"Environment {request.EnvironmentId} has not been found");
            }

            if (environment.Servers?.Count > 0)
            {
                foreach (Domain.Entities.Server server in environment.Servers)
                {
                    if (!server.IsDeleted)
                    {
                        server.SetAsDeleted();

                        var serverLogId = Guid.NewGuid();

                        var serverLog = Domain.Entities.ServerLog.Create(serverLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), server.Id); // Mock!

                        await databaseContext.Logs.AddAsync(serverLog, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            if (!environment.IsDeleted)
            {
                environment.SetAsDeleted();

                var environmentLogId = Guid.NewGuid();

                var environmentLog = Domain.Entities.EnvironmentLog.Create(environmentLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), environment.Id); // Mock!

                await databaseContext.Logs.AddAsync(environmentLog, cancellationToken).ConfigureAwait(false);
            }

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
