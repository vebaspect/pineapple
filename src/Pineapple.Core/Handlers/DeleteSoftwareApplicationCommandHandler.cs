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
    public class DeleteSoftwareApplicationCommandHandler : AsyncRequestHandler<DeleteSoftwareApplicationCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteSoftwareApplicationCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var softwareApplication = await databaseContext
                .SoftwareApplications
                .FirstOrDefaultAsync(softwareApplication => softwareApplication.Id == request.SoftwareApplicationId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (softwareApplication is null)
            {
                throw new SoftwareApplicationNotFoundException($"SoftwareApplication {request.SoftwareApplicationId} has not been found");
            }

            databaseContext.SoftwareApplications.Remove(softwareApplication);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
