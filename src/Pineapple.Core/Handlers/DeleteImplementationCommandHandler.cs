using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class DeleteImplementationCommandHandler : AsyncRequestHandler<DeleteImplementationCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteImplementationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteImplementationCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new ImplementationNotFoundException($"Implementation {request.ImplementationId} has not been found");
            }

            if (!implementation.IsDeleted)
            {
                implementation.SetAsDeleted();

                var implementationLogId = Guid.NewGuid();

                var implementationLog = Domain.Entities.ImplementationLog.Create(implementationLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), request.ImplementationId); // Mock!

                await databaseContext.Logs.AddAsync(implementationLog, cancellationToken).ConfigureAwait(false);
            }

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
