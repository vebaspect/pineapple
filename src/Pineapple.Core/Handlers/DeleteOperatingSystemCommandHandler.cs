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
    public class DeleteOperatingSystemCommandHandler : AsyncRequestHandler<DeleteOperatingSystemCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteOperatingSystemCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteOperatingSystemCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var operatingSystem = await databaseContext
                .OperatingSystems
                .FirstOrDefaultAsync(operatingSystem => operatingSystem.Id == request.OperatingSystemId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (operatingSystem is null)
            {
                throw new OperatingSystemNotFoundException($"OperatingSystem {request.OperatingSystemId} has not been found");
            }

            operatingSystem.SetAsDeleted();

            var operatingSystemLogId = Guid.NewGuid();

            var operatingSystemLog = Domain.Entities.OperatingSystemLog.Create(operatingSystemLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), request.OperatingSystemId); // Mock!

            await databaseContext.Logs.AddAsync(operatingSystemLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
