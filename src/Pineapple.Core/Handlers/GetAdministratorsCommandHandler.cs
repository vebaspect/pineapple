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
    public class GetAdministratorsCommandHandler : RequestHandler<GetAdministratorsCommand, Task<UserDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetAdministratorsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto[]> Handle(GetAdministratorsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var administrators = await databaseContext
                .Users
                .OfType<Domain.Entities.Administrator>()
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (administrators?.Length > 0)
            {
                return administrators.Select(administrator => Map(administrator)).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }

        private static UserDto Map(Domain.Entities.User administrator)
        {
            return new UserDto(
                administrator.Id,
                administrator.ModifiedDate,
                administrator.Type,
                administrator.FullName,
                administrator.Login,
                administrator.Phone,
                administrator.Email
            );
        }
    }
}
