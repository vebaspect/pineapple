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
    public class UninstallComponentCommandHandler : AsyncRequestHandler<UninstallComponentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public UninstallComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(UninstallComponentCommand request, CancellationToken cancellationToken)
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

            var component = await databaseContext
                .ServerComponents
                .FirstOrDefaultAsync(component => component.ServerId == request.ServerId && component.ComponentVersionId == request.ComponentVersionId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (component is null)
            {
                throw new ServerComponentNotFoundException($"ServerComponent {request.ServerId}|{request.ComponentVersionId} has not been found");
            }

            server.UninstallComponent(component);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
