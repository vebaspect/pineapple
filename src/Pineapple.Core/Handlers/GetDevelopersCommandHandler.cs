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
    public class GetDevelopersCommandHandler : RequestHandler<GetDevelopersCommand, Task<UserDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetDevelopersCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto[]> Handle(GetDevelopersCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var developers = await databaseContext
                .Users
                .OfType<Domain.Entities.Developer>()
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (developers?.Length > 0)
            {
                return developers.Select(developer => Map(developer)).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }

        private static UserDto Map(Domain.Entities.User developer)
        {
            return new UserDto(
                developer.Id,
                developer.ModifiedDate,
                developer.Type,
                developer.FullName,
                developer.Login,
                developer.Phone,
                developer.Email
            );
        }
    }
}
