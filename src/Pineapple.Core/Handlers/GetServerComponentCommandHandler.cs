using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetServerComponentCommandHandler : RequestHandler<GetServerComponentCommand, Task<ServerComponentDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServerComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ServerComponentDto> Handle(GetServerComponentCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Servers)
                        .ThenInclude(server => server.InstalledComponents)
                            .ThenInclude(installedComponent => installedComponent.ComponentVersion)
                                .ThenInclude(componentVersion => componentVersion.Component)
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

            var serverComponent = server
                .InstalledComponents?
                .FirstOrDefault(serverComponent => serverComponent.Id == request.ServerComponentId);

            if (serverComponent is null)
            {
                throw new ServerComponentNotFoundException($"ServerComponent {request.ServerComponentId} has not been found");
            }

            return serverComponent.ToDto();
        }
    }
}
