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
                return administrators.Select(administrator => administrator.ToDto()).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }
    }
}
