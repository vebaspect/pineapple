using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

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

            var existingServer = await databaseContext
                .Servers
                .FirstOrDefaultAsync(server => server.Symbol == request.Symbol)
                .ConfigureAwait(false);

            if (!(existingServer is null))
            {
                throw new ServerAlreadyExistsException($"Server {existingServer.Symbol} already exists");
            }

            var serverId = Guid.NewGuid();

            var server = Domain.Entities.Server.Create(serverId, request.Name, request.Symbol, request.IpAddress, request.Description, request.EnvironmentId, request.OperatingSystemId);

            await databaseContext.Servers.AddAsync(server).ConfigureAwait(false);

            var serverLogId = Guid.NewGuid();

            var serverLog = Domain.Entities.ServerLog.Create(serverLogId, AvailableLogCategories.AddEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), serverId); // Mock!

            await databaseContext.Logs.AddAsync(serverLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return serverId;
        }
    }
}
