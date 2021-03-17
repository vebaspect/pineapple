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
    public class GetEnvironmentLogsCommandHandler : RequestHandler<GetEnvironmentLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetEnvironmentLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetEnvironmentLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var environmentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.EnvironmentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Environment)
                .ThenInclude(environment => environment.Implementation)
                .Where(log => log.EnvironmentId == request.EnvironmentId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                .ThenInclude(server => server.Environment)
                .Where(log => log.Server.EnvironmentId == request.EnvironmentId)
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

            return logs
                .OrderByDescending(log => log.ModifiedDate)
                .ToArray();
        }
    }
}
