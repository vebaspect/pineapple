using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetProductLogsCommandHandler : RequestHandler<GetProductLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetProductLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetProductLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Component)
                .ThenInclude(component => component.Product)
                .Where(log => log.Component.ProductId == request.ProductId)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var productLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ProductLog>()
                .Include(log => log.Owner)
                .Include(log => log.Product)
                .Where(log => log.ProductId == request.ProductId)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (componentLogs?.Length > 0)
            {
                logs.AddRange(componentLogs.Select(componentLog => Map(componentLog)));
            }
            if (productLogs?.Length > 0)
            {
                logs.AddRange(productLogs.Select(productLog => Map(productLog)));
            }

            return logs.ToArray();
        }

        private static LogDto Map(Domain.Entities.ComponentLog componentLog)
        {
            return new LogDto(
                componentLog.Id,
                componentLog.ModifiedDate,
                componentLog.IsDeleted,
                componentLog.Type,
                componentLog.Category,
                componentLog.OwnerId,
                componentLog.Owner.FullName,
                componentLog.ComponentId,
                componentLog.Component.Name,
                componentLog.Component.ProductId,
                componentLog.Component.Product.Name,
                componentLog.Description
            );
        }

        private static LogDto Map(Domain.Entities.ProductLog productLog)
        {
            return new LogDto(
                productLog.Id,
                productLog.ModifiedDate,
                productLog.IsDeleted,
                productLog.Type,
                productLog.Category,
                productLog.OwnerId,
                productLog.Owner.FullName,
                productLog.ProductId,
                productLog.Product.Name,
                null,
                null,
                productLog.Description
            );
        }
    }
}
