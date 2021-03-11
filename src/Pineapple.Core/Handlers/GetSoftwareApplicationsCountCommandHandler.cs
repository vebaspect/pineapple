using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetSoftwareApplicationsCountCommandHandler : RequestHandler<GetSoftwareApplicationsCountCommand, Task<int>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetSoftwareApplicationsCountCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<int> Handle(GetSoftwareApplicationsCountCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var softwareApplicationsCount = await databaseContext
                .SoftwareApplications
                .Where(softwareApplication => !softwareApplication.IsDeleted)
                .CountAsync()
                .ConfigureAwait(false);

            return softwareApplicationsCount;
        }
    }
}
