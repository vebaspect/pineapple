using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetImplementationsLogsCommandHandler : RequestHandler<GetImplementationsLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetImplementationsLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetImplementationsLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var logs = await databaseContext
                .Logs
                .OfType<Domain.Entities.ImplementationLog>()
                .Include(log => log.Owner)
                .Include(log => log.Implementation)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (logs?.Length > 0)
            {
                return logs.Select(log => Map(log)).ToArray();
            }

            return Enumerable.Empty<LogDto>().ToArray();
        }

        private static LogDto Map(Domain.Entities.ImplementationLog log)
        {
            return new LogDto(
                log.Id,
                log.ModifiedDate,
                log.IsDeleted,
                log.Type,
                log.Category,
                log.OwnerId,
                log.Owner.FullName,
                log.ImplementationId,
                log.Implementation.Name,
                null,
                null,
                log.Description
            );
        }
    }
}
