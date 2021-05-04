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
    public class InstallSoftwareApplicationCommandHandler : AsyncRequestHandler<InstallSoftwareApplicationCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public InstallSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(InstallSoftwareApplicationCommand request, CancellationToken cancellationToken)
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

            var existingSoftwareApplication = await databaseContext
                .ServerSoftwareApplications
                .FirstOrDefaultAsync(serverSoftwareApplication =>
                    serverSoftwareApplication.SoftwareApplicationId == request.SoftwareApplicationId
                    && serverSoftwareApplication.ServerId == request.ServerId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (!(existingSoftwareApplication is null))
            {
                throw new ServerSoftwareApplicationAlreadyExistsException($"ServerSoftwareApplication {request.ServerId}|{request.SoftwareApplicationId} already exists");
            }

            var serverSoftwareApplication = new Domain.Entities.ServerSoftwareApplication(server.Id, softwareApplication.Id);

            await databaseContext.ServerSoftwareApplications.AddAsync(serverSoftwareApplication, cancellationToken).ConfigureAwait(false);

            server.InstallSoftwareApplication(serverSoftwareApplication);

            var serverSoftwareApplicationLogId = Guid.NewGuid();

            var serverSoftwareApplicationLog = Domain.Entities.ServerSoftwareApplicationLog.Create(serverSoftwareApplicationLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), server.Id, softwareApplication.Id); // Mock!

            await databaseContext.Logs.AddAsync(serverSoftwareApplicationLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
