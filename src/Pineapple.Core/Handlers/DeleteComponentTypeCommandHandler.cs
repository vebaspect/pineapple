using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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
                throw new Exception($"ComponentType {request.ComponentTypeId} not exist");
            }

            databaseContext.ComponentTypes.Remove(componentType);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
