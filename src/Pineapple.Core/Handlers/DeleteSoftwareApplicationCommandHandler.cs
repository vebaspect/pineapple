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

            if (!softwareApplication.IsDeleted)
            {
                softwareApplication.SetAsDeleted();

                var softwareApplicationLogId = Guid.NewGuid();

                var softwareApplicationLog = Domain.Entities.SoftwareApplicationLog.Create(softwareApplicationLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), softwareApplication.Id); // Mock!

                await databaseContext.Logs.AddAsync(softwareApplicationLog, cancellationToken).ConfigureAwait(false);
            }

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
