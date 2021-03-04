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

            var logs = await databaseContext
                .Logs
                .Include(log => log.User)
                .OrderByDescending(log => log.ModifiedDate)
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (logs?.Length > 0)
            {
                return logs.Select(log => Map(log)).ToArray();
            }

            return Enumerable.Empty<LogDto>().ToArray();
        }

        private static LogDto Map(Domain.Entities.Log log)
        {
            return new LogDto(
                log.Id,
                log.ModifiedDate,
                log.Type,
                log.UserId,
                log.User.FullName,
                log.Description
            );
        }
    }
}
