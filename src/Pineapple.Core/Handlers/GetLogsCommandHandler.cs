using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pineapple.Core.Handler
{
    public class GetLogsCommandHandler : RequestHandler<GetLogsCommand, Task<LogDto[]>>, ICommandHandler
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

        protected override async Task<LogDto[]> Handle(GetLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementationLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ImplementationLog>()
                .Include(log => log.User)
                .Include(log => log.Implementation)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var productLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ProductLog>()
                .Include(log => log.User)
                .Include(log => log.Product)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (implementationLogs?.Length > 0)
            {
                logs.AddRange(implementationLogs.Select(implementationLog => Map(implementationLog)));
            }
            if (productLogs?.Length > 0)
            {
                logs.AddRange(productLogs.Select(productLog => Map(productLog)));
            }

            return logs.ToArray();
        }

        private static LogDto Map(Domain.Entities.ImplementationLog implementationLog)
        {
            return new LogDto(
                implementationLog.Id,
                implementationLog.ModifiedDate,
                implementationLog.Type,
                implementationLog.Category,
                implementationLog.UserId,
                implementationLog.User.FullName,
                implementationLog.ImplementationId,
                implementationLog.Implementation.Name,
                implementationLog.Description
            );
        }

        private static LogDto Map(Domain.Entities.ProductLog productLog)
        {
            return new LogDto(
                productLog.Id,
                productLog.ModifiedDate,
                productLog.Type,
                productLog.Category,
                productLog.UserId,
                productLog.User.FullName,
                productLog.ProductId,
                productLog.Product.Name,
                productLog.Description
            );
        }
    }
}
