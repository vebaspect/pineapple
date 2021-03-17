using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateServerCommandHandler : RequestHandler<CreateServerCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateServerCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateServerCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var serverId = Guid.NewGuid();

            var server = Domain.Entities.Server.Create(serverId, request.Name, request.Symbol, request.Description, request.EnvironmentId, request.OperatingSystemId, request.IpAddress);

            await databaseContext.Servers.AddAsync(server).ConfigureAwait(false);

            var serverLogId = Guid.NewGuid();

            var serverLog = Domain.Entities.ServerLog.Create(serverLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), serverId); // Mock!

            await databaseContext.Logs.AddAsync(serverLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return serverId;
        }
    }
}
