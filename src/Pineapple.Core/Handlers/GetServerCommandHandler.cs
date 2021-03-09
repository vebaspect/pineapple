using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

namespace Pineapple.Core.Handler
{
    public class GetServerCommandHandler : RequestHandler<GetServerCommand, Task<ServerDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServerCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ServerDto> Handle(GetServerCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                .ThenInclude(environment => environment.Servers)
                .ThenInclude(environment => environment.OperatingSystem)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new ImplementationNotFoundException($"Implementation {request.ImplementationId} has not been found");
            }

            var environment = implementation
                .Environments?
                .FirstOrDefault(environment => environment.Id == request.EnvironmentId);

            if (environment is null)
            {
                throw new EnvironmentNotFoundException($"Environment {request.EnvironmentId} has not been found");
            }

            var server = environment
                .Servers?
                .FirstOrDefault(server => server.Id == request.ServerId);

            if (server is null)
            {
                throw new ServerNotFoundException($"Server {request.ServerId} has not been found");
            }

            return Map(server);
        }

        private static ServerDto Map(Domain.Entities.Server server)
        {
            return new ServerDto(
                server.Id,
                server.ModifiedDate,
                server.IsDeleted,
                server.Name,
                server.Symbol,
                server.Description,
                server.OperatingSystemId,
                server.OperatingSystem.Name,
                server.IpAddress
            );
        }
    }
}
