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
    public class UninstallServerSoftwareApplicationCommandHandler : AsyncRequestHandler<UninstallServerSoftwareApplicationCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public UninstallServerSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(UninstallServerSoftwareApplicationCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var serverSoftwareApplication = await databaseContext
                .ServerSoftwareApplications
                .Include(serverSoftwareApplication => serverSoftwareApplication.Server)
                    .ThenInclude(server => server.InstalledSoftwareApplications)
                .FirstOrDefaultAsync(serverSoftwareApplication =>
                    serverSoftwareApplication.Id == request.ServerSoftwareApplicationId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (serverSoftwareApplication is null)
            {
                throw new ServerSoftwareApplicationNotFoundException($"ServerSoftwareApplication {request.ServerSoftwareApplicationId} has not been found");
            }

            serverSoftwareApplication.Server.UninstallSoftwareApplication(serverSoftwareApplication);

            var serverSoftwareApplicationLogId = Guid.NewGuid();

            var serverSoftwareApplicationLog = Domain.Entities.ServerSoftwareApplicationLog.Create(serverSoftwareApplicationLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), serverSoftwareApplication.ServerId, serverSoftwareApplication.SoftwareApplicationId); // Mock!

            await databaseContext.Logs.AddAsync(serverSoftwareApplicationLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
