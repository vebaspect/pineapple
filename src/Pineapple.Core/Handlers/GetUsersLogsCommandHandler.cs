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
    public class GetUsersLogsCommandHandler : RequestHandler<GetUsersLogsCommand, Task<LogDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetUsersLogsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<LogDto[]> Handle(GetUsersLogsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var usersLogs = await databaseContext
                .Logs
                .OfType<Domain.Entities.UserLog>()
                .Include(log => log.Owner)
                .Include(log => log.User)
                .ToArrayAsync()
                .ConfigureAwait(false);

            var logs = new List<LogDto>();

            if (usersLogs?.Length > 0)
            {
                logs.AddRange(usersLogs.Select(usersLog => usersLog.ToDto()));
            }

            return logs
                .OrderByDescending(log => log.ModifiedDate)
                .ToArray();
        }
    }
}
