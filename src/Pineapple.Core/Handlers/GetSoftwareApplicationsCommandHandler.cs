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
    public class GetSoftwareApplicationsCommandHandler : RequestHandler<GetSoftwareApplicationsCommand, Task<SoftwareApplicationDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetSoftwareApplicationsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<SoftwareApplicationDto[]> Handle(GetSoftwareApplicationsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            Domain.Entities.SoftwareApplication[] softwareApplications = null;

            if (request.Count.HasValue)
            {
                softwareApplications = await databaseContext
                    .SoftwareApplications
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                softwareApplications = await databaseContext
                    .SoftwareApplications
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (softwareApplications?.Length > 0)
            {
                return softwareApplications.Select(softwareApplication => softwareApplication.ToDto()).ToArray();
            }

            return Enumerable.Empty<SoftwareApplicationDto>().ToArray();
        }
    }
}
