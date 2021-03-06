using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto.Logs;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetProductLogsCommandHandler : RequestHandler<GetProductLogsCommand, Task<ILogDto[]>>, ICommandHandler
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

        protected override async Task<ILogDto[]> Handle(GetProductLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var product = await databaseContext
                .Products
                .FirstOrDefaultAsync(product => product.Id == request.ProductId)
                .ConfigureAwait(false);

            if (product is null)
            {
                throw new ProductNotFoundException($"Product {request.ProductId} has not been found");
            }

            var productLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ProductLog>()
                .Include(log => log.Owner)
                .Include(log => log.Product)
                .Where(log => log.ProductId == request.ProductId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var componentLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentLog>()
                .Include(log => log.Owner)
                .Include(log => log.Component)
                    .ThenInclude(component => component.Product)
                .Where(log => log.Component.ProductId == request.ProductId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var componentVersionLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ComponentVersionLog>()
                .Include(log => log.Owner)
                .Include(log => log.ComponentVersion)
                    .ThenInclude(componentVersion => componentVersion.Component)
                .Where(log => log.ComponentVersion.Component.ProductId == request.ProductId)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<ILogDto>();

            if (productLogs?.Length > 0)
            {
                logs.AddRange(productLogs.Select(productLog => productLog.ToDto()));
            }
            if (componentLogs?.Length > 0)
            {
                logs.AddRange(componentLogs.Select(componentLog => componentLog.ToDto()));
            }
            if (componentVersionLogs?.Length > 0)
            {
                logs.AddRange(componentVersionLogs.Select(componentVersionLog => componentVersionLog.ToDto()));
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
