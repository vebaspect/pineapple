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
    public class GetServerSoftwareApplicationsCommandHandler : RequestHandler<GetServerSoftwareApplicationsCommand, Task<ServerSoftwareApplicationDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServerSoftwareApplicationsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ServerSoftwareApplicationDto[]> Handle(GetServerSoftwareApplicationsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                    .ThenInclude(environment => environment.Servers)
                        .ThenInclude(server => server.InstalledSoftwareApplications)
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

            if (server.InstalledSoftwareApplications?.Count > 0)
            {
                return server
                    .InstalledSoftwareApplications
                    .Select(installedSoftwareApplication => new ServerSoftwareApplicationDto(installedSoftwareApplication.SoftwareApplicationId))
                    .ToArray();
            }

            return Enumerable
                .Empty<ServerSoftwareApplicationDto>()
                .ToArray();
        }
    }
}
