using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetServersCommandHandler : RequestHandler<GetServersCommand, Task<ServerDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServersCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ServerDto[]> Handle(GetServersCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                .ThenInclude(environment => environment.Servers)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new Exception($"Implementation {request.ImplementationId} not exist");
            }

            var environment = implementation
                .Environments?
                .FirstOrDefault(environment => environment.Id == request.EnvironmentId);

            if (environment is null)
            {
                throw new Exception($"Environment {request.EnvironmentId} not exist");
            }

            if (environment.Servers?.Count > 0)
            {
                return environment.Servers.Select(server => Map(server)).ToArray();
            }

            return Enumerable.Empty<ServerDto>().ToArray();
        }

        private static ServerDto Map(Domain.Entities.Server server)
        {
            return new ServerDto(server.Id, server.ModifiedDate, server.Name, server.Symbol, server.Description, server.OperatingSystemId);
        }
    }
}
