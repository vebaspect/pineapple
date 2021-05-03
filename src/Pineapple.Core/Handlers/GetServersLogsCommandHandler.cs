using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetServersLogsCommandHandler : RequestHandler<GetServersLogsCommand, Task<LogDto[]>>, ICommandHandler
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

        protected override async Task<LogDto[]> Handle(GetServersLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                        .ThenInclude(environment => environment.Implementation)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (serverLogs?.Length > 0)
            {
                logs.AddRange(serverLogs.Select(serverLog => serverLog.ToDto()).ToArray());
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
