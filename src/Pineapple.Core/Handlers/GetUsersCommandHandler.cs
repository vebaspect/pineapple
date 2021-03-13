using System;
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
    public class GetUsersCommandHandler : RequestHandler<GetUsersCommand, Task<UserDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetUsersCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto[]> Handle(GetUsersCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var users = await databaseContext
                .Users
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (users?.Length > 0)
            {
                return users.Select(user => user.ToDto()).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }
    }
}
