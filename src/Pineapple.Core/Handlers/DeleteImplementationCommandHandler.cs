using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class DeleteImplementationCommandHandler : AsyncRequestHandler<DeleteImplementationCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteImplementationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteImplementationCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                .ThenInclude(environment => environment.Servers)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new ImplementationNotFoundException($"Implementation {request.ImplementationId} has not been found");
            }

            if (implementation.Environments?.Count > 0)
            {
                foreach (Domain.Entities.Environment environment in implementation.Environments)
                {
                    if (!environment.IsDeleted)
                    {
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

                        environment.SetAsDeleted();

                        var environmentLogId = Guid.NewGuid();

                        var environmentLog = Domain.Entities.EnvironmentLog.Create(environmentLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), environment.Id); // Mock!

                        await databaseContext.Logs.AddAsync(environmentLog, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            if (!implementation.IsDeleted)
            {
                implementation.SetAsDeleted();

                var implementationLogId = Guid.NewGuid();

                var implementationLog = Domain.Entities.ImplementationLog.Create(implementationLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), implementation.Id); // Mock!

                await databaseContext.Logs.AddAsync(implementationLog, cancellationToken).ConfigureAwait(false);
            }

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
