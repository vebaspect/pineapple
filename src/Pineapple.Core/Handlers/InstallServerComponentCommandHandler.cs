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
    public class InstallServerComponentCommandHandler : AsyncRequestHandler<InstallServerComponentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public InstallServerComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(InstallServerComponentCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentVersion = await databaseContext
                .ComponentVersions
                .FirstOrDefaultAsync(componentVersion =>
                    componentVersion.Id == request.ComponentVersionId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (componentVersion is null)
            {
                throw new ComponentVersionNotFoundException($"ComponentVersion {request.ComponentVersionId} has not been found");
            }

            var server = await databaseContext
                .Servers
                .Include(server => server.InstalledComponents)
                .FirstOrDefaultAsync(server =>
                    server.Id == request.ServerId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (server is null)
            {
                throw new ServerNotFoundException($"Server {request.ServerId} has not been found");
            }

            var existingServerComponent = await databaseContext
                .ServerComponents
                .FirstOrDefaultAsync(serverComponent =>
                    serverComponent.ComponentVersionId == request.ComponentVersionId
                    && serverComponent.ServerId == request.ServerId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (!(existingServerComponent is null))
            {
                throw new ServerComponentAlreadyExistsException($"ServerComponent {request.ServerId}|{request.ComponentVersionId} already exists");
            }

            var serverComponent = new Domain.Entities.ServerComponent(server.Id, componentVersion.Id);

            await databaseContext.ServerComponents.AddAsync(serverComponent, cancellationToken).ConfigureAwait(false);

            server.InstallComponent(serverComponent);

            var serverComponentLogId = Guid.NewGuid();

            var serverComponentLog = Domain.Entities.ServerComponentLog.Create(serverComponentLogId, AvailableLogCategories.CreateEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), server.Id, componentVersion.Id); // Mock!

            await databaseContext.Logs.AddAsync(serverComponentLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
