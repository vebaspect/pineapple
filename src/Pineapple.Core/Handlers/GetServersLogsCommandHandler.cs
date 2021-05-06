using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto.Logs;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetServersLogsCommandHandler : RequestHandler<GetServersLogsCommand, Task<ILogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetServersLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ILogDto[]> Handle(GetServersLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Where(log => !(log is Domain.Entities.ServerComponentLog) && !(log is Domain.Entities.ServerSoftwareApplicationLog))
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                        .ThenInclude(environment => environment.Implementation)
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
