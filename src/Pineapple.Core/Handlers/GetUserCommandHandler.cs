using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Mappers;
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
                throw new UserNotFoundException($"User {request.UserId} has not been found");
            }

            return user.ToDto();
        }
    }
}
