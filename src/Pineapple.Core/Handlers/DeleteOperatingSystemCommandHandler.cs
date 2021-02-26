using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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
                throw new Exception($"OperatingSystem {request.OperatingSystemId} not exist");
            }

            databaseContext.OperatingSystems.Remove(operatingSystem);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}