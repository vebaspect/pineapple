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
    public class GetConfigurationLogsCommandHandler : RequestHandler<GetConfigurationLogsCommand, Task<ILogDto[]>>, ICommandHandler
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

        protected override async Task<ILogDto[]> Handle(GetConfigurationLogsCommand request)
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

            var softwareApplicationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.SoftwareApplicationLog>()
                .Include(log => log.Owner)
                .Include(log => log.SoftwareApplication)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<ILogDto>();

            if (componentTypeLogs?.Length > 0)
            {
                logs.AddRange(componentTypeLogs.Select(componentTypeLog => componentTypeLog.ToDto()));
            }
            if (operatingSystemLogs?.Length > 0)
            {
                logs.AddRange(operatingSystemLogs.Select(operatingSystemLog => operatingSystemLog.ToDto()));
            }
            if (softwareApplicationLogs?.Length > 0)
            {
                logs.AddRange(softwareApplicationLogs.Select(softwareApplicationLog => softwareApplicationLog.ToDto()));
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
