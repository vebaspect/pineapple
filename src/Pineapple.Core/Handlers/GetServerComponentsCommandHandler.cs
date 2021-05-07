using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetServerComponentsCommandHandler : RequestHandler<GetServerComponentsCommand, Task<ServerComponentDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServerComponentsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ServerComponentDto[]> Handle(GetServerComponentsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Servers)
                        .ThenInclude(server => server.InstalledComponents)
                            .ThenInclude(installedComponent => installedComponent.ComponentVersion)
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

            if (server.InstalledComponents?.Count > 0)
            {
                return server
                    .InstalledComponents
                    .Select(installedComponent => new ServerComponentDto(installedComponent.ComponentVersion.ComponentId))
                    .ToArray();
            }

            return Enumerable
                .Empty<ServerComponentDto>()
                .ToArray();
        }
    }
}
