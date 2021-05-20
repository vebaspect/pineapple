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
    public class UninstallServerComponentCommandHandler : AsyncRequestHandler<UninstallServerComponentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public UninstallServerComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(UninstallServerComponentCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var serverComponent = await databaseContext
                .ServerComponents
                .Include(serverComponent => serverComponent.Server)
                    .ThenInclude(server => server.InstalledComponents)
                .FirstOrDefaultAsync(serverComponent =>
                    serverComponent.Id == request.ServerComponentId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (serverComponent is null)
            {
                throw new ServerComponentNotFoundException($"ServerComponent {request.ServerComponentId} has not been found");
            }

            serverComponent.Server.UninstallComponent(serverComponent);

            var serverComponentLogId = Guid.NewGuid();

            var serverComponentLog = Domain.Entities.ServerComponentLog.Create(serverComponentLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), serverComponent.ServerId, serverComponent.ComponentVersionId); // Mock!

            await databaseContext.Logs.AddAsync(serverComponentLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
