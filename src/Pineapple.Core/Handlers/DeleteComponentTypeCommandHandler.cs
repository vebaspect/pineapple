using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Pineapple.Core.Exceptions;

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

            databaseContext.ComponentTypes.Remove(componentType);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
