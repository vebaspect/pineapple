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
    public class GetManagersCommandHandler : RequestHandler<GetManagersCommand, Task<UserDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetManagersCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto[]> Handle(GetManagersCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var managers = await databaseContext
                .Users
                .OfType<Domain.Entities.Manager>()
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (managers?.Length > 0)
            {
                return managers.Select(manager => Map(manager)).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }

        private static UserDto Map(Domain.Entities.User manager)
        {
            return new UserDto(
                manager.Id,
                manager.ModifiedDate,
                manager.IsDeleted,
                manager.Type,
                manager.FullName,
                manager.Login,
                manager.Phone,
                manager.Email
            );
        }
    }
}
