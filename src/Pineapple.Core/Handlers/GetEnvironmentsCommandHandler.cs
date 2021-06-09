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
    public class GetEnvironmentsCommandHandler : RequestHandler<GetEnvironmentsCommand, Task<EnvironmentDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetEnvironmentsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<EnvironmentDto[]> Handle(GetEnvironmentsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Operator)
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

            if (implementation.Environments?.Count > 0)
            {
                return implementation.Environments
                    .OrderBy(environment => environment.Name)
                    .Select(environment => environment.ToDto()).ToArray();
            }

            return Enumerable.Empty<EnvironmentDto>().ToArray();
        }
    }
}
