using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetOperatingSystemsCountCommandHandler : RequestHandler<GetOperatingSystemsCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetOperatingSystemsCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetOperatingSystemsCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var operatingSystemsCount = await databaseContext
                .OperatingSystems
                .CountAsync()
                .ConfigureAwait(false);

            return operatingSystemsCount;
        }
    }
}
