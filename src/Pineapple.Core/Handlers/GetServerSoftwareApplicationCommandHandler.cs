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
    public class GetServerSoftwareApplicationCommandHandler : RequestHandler<GetServerSoftwareApplicationCommand, Task<ServerSoftwareApplicationDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServerSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ServerSoftwareApplicationDto> Handle(GetServerSoftwareApplicationCommand request)
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

            var serverSoftwareApplication = server
                .InstalledSoftwareApplications?
                .FirstOrDefault(serverSoftwareApplication => serverSoftwareApplication.Id == request.ServerSoftwareApplicationId);

            if (serverSoftwareApplication is null)
            {
                throw new ServerSoftwareApplicationNotFoundException($"ServerSoftwareApplication {request.ServerSoftwareApplicationId} has not been found");
            }

            return serverSoftwareApplication.ToDto();
        }
    }
}
