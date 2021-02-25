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

            var server = new Domain.Entities.Server()
            {
                Id = serverId,
                ModifiedDate = DateTime.Now,
                Name = request.Name,
                Symbol = request.Symbol,
                Description = request.Description,
                EnvironmentId = request.EnvironmentId,
                OperatingSystemId = request.OperatingSystemId,
                IPAddress = request.IPAddress,
            };

            await databaseContext.Servers.AddAsync(server).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return serverId;
        }
    }
}
