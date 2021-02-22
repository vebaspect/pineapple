using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetVersionCommandHandler : RequestHandler<GetVersionCommand, Task<VersionDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetVersionCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<VersionDto> Handle(GetVersionCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var product = await databaseContext
                .Products
                .Include(product => product.Components)
                .ThenInclude(component => component.Versions)
                .FirstOrDefaultAsync(product => product.Id == request.ProductId)
                .ConfigureAwait(false);

            if (product is null)
            {
                throw new Exception($"Product {request.ProductId} not exist");
            }

            var component = product
                .Components?
                .FirstOrDefault(component => component.Id == request.ComponentId);

            if (component is null)
            {
                throw new Exception($"Component {request.ComponentId} not exist");
            }

            var version = component
                .Versions?
                .FirstOrDefault(version => version.Id == request.VersionId);

            if (version is null)
            {
                throw new Exception($"Version {request.VersionId} not exist");
            }

            return Map(version);
        }

        private static VersionDto Map(Domain.Entities.Version version)
        {
            return new VersionDto(version.Id, version.ModifiedDate, version.Major, version.Minor, version.Patch, version.PreRelease, version.Description);
        }
    }
}
