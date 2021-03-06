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
                        .ThenInclude(environment => environment.OperatingSystem)
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Servers)
                        .ThenInclude(server => server.InstalledComponents)
                            .ThenInclude(installedComponent => installedComponent.ComponentVersion)
                                .ThenInclude(componentVersion => componentVersion.Component)
                                    .ThenInclude(component => component.Product)
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Servers)
                        .ThenInclude(server => server.InstalledComponents)
                            .ThenInclude(installedComponent => installedComponent.ComponentVersion)
                                .ThenInclude(componentVersion => componentVersion.Component)
                                    .ThenInclude(component => component.ComponentVersions)
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

            if (environment.Servers?.Count > 0)
            {
                return environment.Servers
                    .OrderBy(server => server.Name)
                    .Select(server => server.ToDto()).ToArray();
            }

            return Enumerable.Empty<ServerDto>().ToArray();
        }
    }
}
