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
    public class GetConfigurationLogsCommandHandler : RequestHandler<GetConfigurationLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetConfigurationLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetConfigurationLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentTypeLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentTypeLog>()
                .Include(log => log.Owner)
                .Include(log => log.ComponentType)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var operatingSystemLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.OperatingSystemLog>()
                .Include(log => log.Owner)
                .Include(log => log.OperatingSystem)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (componentTypeLogs?.Length > 0)
            {
                logs.AddRange(componentTypeLogs.Select(componentTypeLog => componentTypeLog.ToDto()));
            }
            if (operatingSystemLogs?.Length > 0)
            {
                logs.AddRange(operatingSystemLogs.Select(operatingSystemLog => operatingSystemLog.ToDto()));
            }

            return logs
                .OrderByDescending(log => log.ModifiedDate)
                .ToArray();
        }
    }
}
