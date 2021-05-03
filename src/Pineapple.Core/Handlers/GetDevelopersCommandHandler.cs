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

            Domain.Entities.Developer[] developers = null;

            if (request.Count.HasValue)
            {
                developers = await databaseContext
                    .Users
                    .OfType<Domain.Entities.Developer>()
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                developers = await databaseContext
                    .Users
                    .OfType<Domain.Entities.Developer>()
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (developers?.Length > 0)
            {
                return developers
                    .OrderBy(developer => developer.FullName)
                    .Select(developer => developer.ToDto()).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }
    }
}
