using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetManagersCountCommandHandler : RequestHandler<GetManagersCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetManagersCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetManagersCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var managersCount = await databaseContext
                .Users
                .OfType<Domain.Entities.Manager>()
                .CountAsync()
                .ConfigureAwait(false);

            return managersCount;
        }
    }
}
