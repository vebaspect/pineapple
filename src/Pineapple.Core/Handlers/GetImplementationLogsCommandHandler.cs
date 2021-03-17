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
    public class GetImplementationLogsCommandHandler : RequestHandler<GetImplementationLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetImplementationLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetImplementationLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var environmentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.EnvironmentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Environment)
                .ThenInclude(environment => environment.Implementation)
                .Where(log => log.Environment.ImplementationId == request.ImplementationId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var implementationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ImplementationLog>()
                .Include(log => log.Owner)
                .Include(log => log.Implementation)
                .Where(log => log.ImplementationId == request.ImplementationId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                .ThenInclude(server => server.Environment)
                .Where(log => log.Server.Environment.ImplementationId == request.ImplementationId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (environmentLogs?.Length > 0)
            {
                logs.AddRange(environmentLogs.Select(environmentLog => environmentLog.ToDto()));
            }
            if (implementationLogs?.Length > 0)
            {
                logs.AddRange(implementationLogs.Select(implementationLog => implementationLog.ToDto()));
            }
            if (serverLogs?.Length > 0)
            {
                logs.AddRange(serverLogs.Select(serverLog => serverLog.ToDto()));
            }

            return logs
                .OrderByDescending(log => log.ModifiedDate)
                .ToArray();
        }
    }
}
