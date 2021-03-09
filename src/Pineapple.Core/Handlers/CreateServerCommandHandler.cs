using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
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

            databaseContext.SaveChanges();

            return serverId;
        }
    }
}
