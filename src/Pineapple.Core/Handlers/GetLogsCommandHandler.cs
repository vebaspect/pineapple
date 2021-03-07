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
                .Include(log => log.Owner)
                .Include(log => log.Implementation)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var productLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ProductLog>()
                .Include(log => log.Owner)
                .Include(log => log.Product)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var userLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.UserLog>()
                .Include(log => log.Owner)
                .Include(log => log.User)
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
            if (userLogs?.Length > 0)
            {
                logs.AddRange(userLogs.Select(userLog => Map(userLog)));
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
                implementationLog.OwnerId,
                implementationLog.Owner.FullName,
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
                productLog.OwnerId,
                productLog.Owner.FullName,
                productLog.ProductId,
                productLog.Product.Name,
                productLog.Description
            );
        }

        private static LogDto Map(Domain.Entities.UserLog userLog)
        {
            return new LogDto(
                userLog.Id,
                userLog.ModifiedDate,
                userLog.Type,
                userLog.Category,
                userLog.OwnerId,
                userLog.Owner.FullName,
                userLog.UserId,
                userLog.User.FullName,
                userLog.Description
            );
        }
    }
}
