using System;
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
    public class DeleteComponentTypeCommandHandler : AsyncRequestHandler<DeleteComponentTypeCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteComponentTypeCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteComponentTypeCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentType = await databaseContext
                .ComponentTypes
                .FirstOrDefaultAsync(componentType => componentType.Id == request.ComponentTypeId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (componentType is null)
            {
                throw new ComponentTypeNotFoundException($"ComponentType {request.ComponentTypeId} has not been found");
            }

            componentType.SetAsDeleted();

            var componentTypeLogId = Guid.NewGuid();

            var componentTypeLog = Domain.Entities.ComponentTypeLog.Create(componentTypeLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), request.ComponentTypeId); // Mock!

            await databaseContext.Logs.AddAsync(componentTypeLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
