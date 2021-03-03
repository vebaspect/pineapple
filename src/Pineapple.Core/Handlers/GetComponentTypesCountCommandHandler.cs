using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetComponentTypesCountCommandHandler : RequestHandler<GetComponentTypesCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentTypesCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetComponentTypesCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentTypesCount = await databaseContext
                .ComponentTypes
                .CountAsync()
                .ConfigureAwait(false);

            return componentTypesCount;
        }
    }
}
