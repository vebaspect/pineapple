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

            Domain.Entities.Manager[] managers = null;

            if (request.Count.HasValue)
            {
                managers = await databaseContext
                    .Users
                    .OfType<Domain.Entities.Manager>()
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                managers = await databaseContext
                    .Users
                    .OfType<Domain.Entities.Manager>()
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (managers?.Length > 0)
            {
                return managers
                    .OrderBy(manager => manager.FullName)
                    .Select(manager => manager.ToDto()).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }
    }
}
