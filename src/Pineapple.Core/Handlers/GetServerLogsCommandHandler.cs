using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto.Logs;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetServerLogsCommandHandler : RequestHandler<GetServerLogsCommand, Task<ILogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServerLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ILogDto[]> Handle(GetServerLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var server = await databaseContext
                .Servers
                .FirstOrDefaultAsync(server => server.Id == request.ServerId)
                .ConfigureAwait(false);

            if (server is null)
            {
                throw new ServerNotFoundException($"Server {request.ServerId} has not been found");
            }

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Where(log => !(log is Domain.Entities.ServerComponentLog) && !(log is Domain.Entities.ServerSoftwareApplicationLog))
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                        .ThenInclude(environment => environment.Implementation)
                .Where(log => log.ServerId == request.ServerId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverComponentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerComponentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                        .ThenInclude(environment => environment.Implementation)
                .Include(log => log.ServerComponentVersion)
                    .ThenInclude(componentVersion => componentVersion.Component)
                        .ThenInclude(component => component.Product)
                .Where(log => log.ServerId == request.ServerId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverSoftwareApplicationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerSoftwareApplicationLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                        .ThenInclude(environment => environment.Implementation)
                .Include(log => log.ServerSoftwareApplication)
                .Where(log => log.ServerId == request.ServerId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<ILogDto>();

            if (serverLogs?.Length > 0)
            {
                logs.AddRange(serverLogs.Select(serverLog => serverLog.ToDto()).ToArray());
            }
            if (serverComponentLogs?.Length > 0)
            {
                logs.AddRange(serverComponentLogs.Select(serverComponentLog => serverComponentLog.ToDto()));
            }
            if (serverSoftwareApplicationLogs?.Length > 0)
            {
                logs.AddRange(serverSoftwareApplicationLogs.Select(serverSoftwareApplicationLog => serverSoftwareApplicationLog.ToDto()));
            }

            if (request.Count.HasValue)
            {
                return logs
                    .OrderByDescending(log => log.ModificationDate)
                    .Take(request.Count.Value)
                    .ToArray();
            }

            return logs
                .OrderByDescending(log => log.ModificationDate)
                .ToArray();
        }
    }
}
