using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto.ImplementationsTree;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetImplementationsTreeCommandHandler : RequestHandler<GetImplementationsTreeCommand, Task<ImplementationsTreeDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetImplementationsTreeCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ImplementationsTreeDto> Handle(GetImplementationsTreeCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementations = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Servers)
                        .ThenInclude(server => server.InstalledComponents)
                            .ThenInclude(installedComponent => installedComponent.ComponentVersion)
                                .ThenInclude(componentVersion => componentVersion.Component)
                                    .ThenInclude(component => component.ComponentVersions)
                .ToListAsync()
                .ConfigureAwait(false);

            ImplementationsTreeDto implementationsTree = new();

            if (implementations.Count > 0)
            {
                foreach (var implementation in implementations)
                {
                    ImplementationNodeDto implementationNode = new()
                    {
                        Id = implementation.Id,
                        IsDeleted = implementation.IsDeleted,
                        Name = implementation.Name,
                        Description = implementation.Description
                    };

                    implementationsTree.Implementations.Add(implementationNode);

                    if (implementation.Environments.Count > 0)
                    {
                        foreach (var environment in implementation.Environments)
                        {
                            bool isUpdateAvailable = false;
                            if (environment.Servers.Count > 0)
                            {
                                foreach (var server in environment.Servers)
                                {
                                    if (server.InstalledComponents.Count > 0)
                                    {
                                        foreach (var installedComponent in server.InstalledComponents)
                                        {
                                            if (installedComponent.ComponentVersion != installedComponent.ComponentVersion.Component.GetLatestVersion())
                                            {
                                                isUpdateAvailable = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (isUpdateAvailable)
                                    {
                                        break;
                                    }
                                }
                            }

                            EnvironmentNodeDto environmentNode = new()
                            {
                                Id = environment.Id,
                                IsDeleted = environment.IsDeleted,
                                Name = environment.Name,
                                Description = environment.Description,
                                IsUpdateAvailable = isUpdateAvailable
                            };

                            implementationNode.Environments.Add(environmentNode);
                        }

                        implementationNode.Environments = implementationNode.Environments
                            .OrderBy((environmentNode) => environmentNode.Name)
                            .ToList();
                    }
                }

                implementationsTree.Implementations = implementationsTree.Implementations
                    .OrderBy((implementationNode) => implementationNode.Name)
                    .ToList();
            }

            return implementationsTree;
        }
    }
}
