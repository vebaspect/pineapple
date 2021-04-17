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
    public class GetEnvironmentsLogsCommandHandler : RequestHandler<GetEnvironmentsLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetEnvironmentsLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetEnvironmentsLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var environmentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.EnvironmentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Environment)
                .ThenInclude(environment => environment.Implementation)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                .ThenInclude(server => server.Environment)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (environmentLogs?.Length > 0)
            {
                logs.AddRange(environmentLogs.Select(environmentLog => environmentLog.ToDto()).ToArray());
            }
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
