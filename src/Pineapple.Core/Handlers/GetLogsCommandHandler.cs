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
    public class GetLogsCommandHandler : RequestHandler<GetLogsCommand, Task<ILogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ILogDto[]> Handle(GetLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Component)
                    .ThenInclude(component => component.Product)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var componentTypeLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentTypeLog>()
                .Include(log => log.Owner)
                .Include(log => log.ComponentType)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var componentVersionLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentVersionLog>()
                .Include(log => log.Owner)
                .Include(log => log.ComponentVersion)
                    .ThenInclude(componentVersion => componentVersion.Component)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var environmentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.EnvironmentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Environment)
                    .ThenInclude(environment => environment.Implementation)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var implementationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ImplementationLog>()
                .Include(log => log.Owner)
                .Include(log => log.Implementation)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var operatingSystemLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.OperatingSystemLog>()
                .Include(log => log.Owner)
                .Include(log => log.OperatingSystem)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var productLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ProductLog>()
                .Include(log => log.Owner)
                .Include(log => log.Product)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerLog>()
                .Where(log => !(log is Domain.Entities.ServerComponentLog) && !(log is Domain.Entities.ServerSoftwareApplicationLog))
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverComponentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerComponentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                .Include(log => log.ServerComponentVersion)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var serverSoftwareApplicationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ServerSoftwareApplicationLog>()
                .Include(log => log.Owner)
                .Include(log => log.Server)
                    .ThenInclude(server => server.Environment)
                .Include(log => log.ServerSoftwareApplication)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var softwareApplicationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.SoftwareApplicationLog>()
                .Include(log => log.Owner)
                .Include(log => log.SoftwareApplication)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var userLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.UserLog>()
                .Include(log => log.Owner)
                .Include(log => log.User)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<ILogDto>();

            if (componentLogs?.Length > 0)
            {
                logs.AddRange(componentLogs.Select(componentLog => componentLog.ToDto()));
            }
            if (componentTypeLogs?.Length > 0)
            {
                logs.AddRange(componentTypeLogs.Select(componentTypeLog => componentTypeLog.ToDto()));
            }
            if (componentVersionLogs?.Length > 0)
            {
                logs.AddRange(componentVersionLogs.Select(componentVersionLog => componentVersionLog.ToDto()));
            }
            if (environmentLogs?.Length > 0)
            {
                logs.AddRange(environmentLogs.Select(environmentLog => environmentLog.ToDto()));
            }
            if (implementationLogs?.Length > 0)
            {
                logs.AddRange(implementationLogs.Select(implementationLog => implementationLog.ToDto()));
            }
            if (operatingSystemLogs?.Length > 0)
            {
                logs.AddRange(operatingSystemLogs.Select(operatingSystemLog => operatingSystemLog.ToDto()));
            }
            if (productLogs?.Length > 0)
            {
                logs.AddRange(productLogs.Select(productLog => productLog.ToDto()));
            }
            if (serverLogs?.Length > 0)
            {
                logs.AddRange(serverLogs.Select(serverLog => serverLog.ToDto()));
            }
            if (serverComponentLogs?.Length > 0)
            {
                logs.AddRange(serverComponentLogs.Select(serverComponentLog => serverComponentLog.ToDto()));
            }
            if (serverSoftwareApplicationLogs?.Length > 0)
            {
                logs.AddRange(serverSoftwareApplicationLogs.Select(serverSoftwareApplicationLog => serverSoftwareApplicationLog.ToDto()));
            }
            if (softwareApplicationLogs?.Length > 0)
            {
                logs.AddRange(softwareApplicationLogs.Select(softwareApplicationLog => softwareApplicationLog.ToDto()));
            }
            if (userLogs?.Length > 0)
            {
                logs.AddRange(userLogs.Select(userLog => userLog.ToDto()));
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
