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
    public class UpdateServerComponentCommandHandler : AsyncRequestHandler<UpdateServerComponentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public UpdateServerComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(UpdateServerComponentCommand request, CancellationToken cancellationToken)
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

            var serverComponent = await databaseContext
                .ServerComponents
                .FirstOrDefaultAsync(serverComponent =>
                    serverComponent.Id == request.ServerComponentId,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            if (serverComponent is null)
            {
                throw new ServerComponentNotFoundException($"ServerComponent {request.ServerComponentId} has not been found");
            }

            serverComponent.UpdateComponent(request.ComponentVersionId);

            var serverComponentLogId = Guid.NewGuid();

            var serverComponentLog = Domain.Entities.ServerComponentLog.Create(serverComponentLogId, AvailableLogCategories.ModifyEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), serverComponent.ServerId, serverComponent.ComponentVersionId); // Mock!

            await databaseContext.Logs.AddAsync(serverComponentLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
