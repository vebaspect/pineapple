using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Commands;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Storage.Database;

namespace Pineapple.Core.Handler
{
    public class InstallComponentCommandHandler : AsyncRequestHandler<InstallComponentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public InstallComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(InstallComponentCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentVersion = await databaseContext
                .ComponentVersions
                .FirstOrDefaultAsync(componentVersion => componentVersion.Id == request.ComponentVersionId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (componentVersion is null)
            {
                throw new ComponentVersionNotFoundException($"ComponentVersion {request.ComponentVersionId} has not been found");
            }

            var server = await databaseContext
                .Servers
                .Include(server => server.InstalledComponents)
                .FirstOrDefaultAsync(server => server.Id == request.ServerId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (server is null)
            {
                throw new ServerNotFoundException($"Server {request.ServerId} has not been found");
            }

            var existingComponent = await databaseContext
                .ServerComponents
                .FirstOrDefaultAsync(component =>
                    component.ComponentVersionId == request.ComponentVersionId
                    && component.ServerId == request.ServerId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (!(existingComponent is null))
            {
                throw new ServerComponentAlreadyExistsException($"ServerComponent {request.ServerId}|{request.ComponentVersionId} already exists");
            }

            var component = new Domain.Entities.ServerComponent(server.Id, componentVersion.Id);

            await databaseContext.ServerComponents.AddAsync(component, cancellationToken).ConfigureAwait(false);

            server.InstallComponent(component);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
