using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetDevelopersCountCommandHandler : RequestHandler<GetDevelopersCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetDevelopersCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetDevelopersCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var developersCount = await databaseContext
                .Users
                .OfType<Domain.Entities.Developer>()
                .CountAsync()
                .ConfigureAwait(false);

            return developersCount;
        }
    }
}
