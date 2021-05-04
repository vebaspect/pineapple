using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Storage.Database;

namespace Pineapple.Core.Handler
{
    public class UninstallSoftwareApplicationCommandHandler : AsyncRequestHandler<UninstallSoftwareApplicationCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public UninstallSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(UninstallSoftwareApplicationCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var softwareApplication = await databaseContext
                .SoftwareApplications
                .FirstOrDefaultAsync(softwareApplication =>
                    softwareApplication.Id == request.SoftwareApplicationId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (softwareApplication is null)
            {
                throw new SoftwareApplicationNotFoundException($"SoftwareApplication {request.SoftwareApplicationId} has not been found");
            }

            var server = await databaseContext
                .Servers
                .Include(server => server.InstalledSoftwareApplications)
                .FirstOrDefaultAsync(server =>
                    server.Id == request.ServerId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (server is null)
            {
                throw new ServerNotFoundException($"Server {request.ServerId} has not been found");
            }

            var serverSoftwareApplication = await databaseContext
                .ServerSoftwareApplications
                .FirstOrDefaultAsync(serverSoftwareApplication =>
                    serverSoftwareApplication.ServerId == request.ServerId
                    && serverSoftwareApplication.SoftwareApplicationId == request.SoftwareApplicationId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (serverSoftwareApplication is null)
            {
                throw new ServerSoftwareApplicationNotFoundException($"ServerSoftwareApplication {request.ServerId}|{request.SoftwareApplicationId} has not been found");
            }

            server.UninstallSoftwareApplication(serverSoftwareApplication);

            var serverSoftwareApplicationLogId = Guid.NewGuid();

            var serverSoftwareApplicationLog = Domain.Entities.ServerSoftwareApplicationLog.Create(serverSoftwareApplicationLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), server.Id, softwareApplication.Id); // Mock!

            await databaseContext.Logs.AddAsync(serverSoftwareApplicationLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
