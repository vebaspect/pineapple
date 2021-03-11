using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetAdministratorsCountCommandHandler : RequestHandler<GetAdministratorsCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetAdministratorsCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetAdministratorsCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var administratorsCount = await databaseContext
                .Users
                .OfType<Domain.Entities.Administrator>()
                .Where(administrator => !administrator.IsDeleted)
                .CountAsync()
                .ConfigureAwait(false);

            return administratorsCount;
        }
    }
}
