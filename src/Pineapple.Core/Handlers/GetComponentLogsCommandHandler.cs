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
    public class GetComponentLogsCommandHandler : RequestHandler<GetComponentLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetComponentLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Component)
                .ThenInclude(component => component.Product)
                .Where(log => log.ComponentId == request.ComponentId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var componentVersionLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentVersionLog>()
                .Include(log => log.Owner)
                .Include(log => log.ComponentVersion)
                .ThenInclude(componentVersion => componentVersion.Component)
                .Where(log => log.ComponentVersion.ComponentId == request.ComponentId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (componentLogs?.Length > 0)
            {
                logs.AddRange(componentLogs.Select(componentLog => componentLog.ToDto()).ToArray());
            }
            if (componentVersionLogs?.Length > 0)
            {
                logs.AddRange(componentVersionLogs.Select(componentVersionLog => componentVersionLog.ToDto()).ToArray());
            }

            if (request.Count.HasValue)
            {
                return logs
                    .OrderByDescending(log => log.ModifiedDate)
                    .Take(request.Count.Value)
                    .ToArray();
            }

            return logs
                .OrderByDescending(log => log.ModifiedDate)
                .ToArray();
        }
    }
}
