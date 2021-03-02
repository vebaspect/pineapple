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
    public class GetOperatorsCommandHandler : RequestHandler<GetOperatorsCommand, Task<UserDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetOperatorsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto[]> Handle(GetOperatorsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var users = await databaseContext
                .Users
                .OfType<Domain.Entities.Operator>()
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (users?.Length > 0)
            {
                return users.Select(user => Map(user)).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }

        private static UserDto Map(Domain.Entities.User user)
        {
            return new UserDto(
                user.Id,
                user.ModifiedDate,
                user.Type,
                user.FullName,
                user.Login,
                user.Phone,
                user.Email
            );
        }
    }
}
