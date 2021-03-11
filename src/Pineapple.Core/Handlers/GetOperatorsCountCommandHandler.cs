using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetOperatorsCountCommandHandler : RequestHandler<GetOperatorsCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetOperatorsCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetOperatorsCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var operatorsCount = await databaseContext
                .Users
                .OfType<Domain.Entities.Operator>()
                .Where(@operator => !@operator.IsDeleted)
                .CountAsync()
                .ConfigureAwait(false);

            return operatorsCount;
        }
    }
}
