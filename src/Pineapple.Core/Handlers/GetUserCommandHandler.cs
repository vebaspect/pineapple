using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetUserCommandHandler : RequestHandler<GetUserCommand, Task<UserDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetUserCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto> Handle(GetUserCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var user = await databaseContext
                .Users
                .FirstOrDefaultAsync(user => user.Id == request.UserId)
                .ConfigureAwait(false);

            if (user is null)
            {
                throw new Exception($"User {request.UserId} not exist");
            }

            return Map(user);
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
