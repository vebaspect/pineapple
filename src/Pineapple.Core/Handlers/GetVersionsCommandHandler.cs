using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

namespace Pineapple.Core.Handler
{
    public class GetVersionsCommandHandler : RequestHandler<GetVersionsCommand, Task<VersionDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetVersionsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<VersionDto[]> Handle(GetVersionsCommand request)
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
                throw new ProductNotFoundException($"Product {request.ProductId} has not been found");
            }

            var component = product
                .Components?
                .FirstOrDefault(component => component.Id == request.ComponentId);

            if (component is null)
            {
                throw new ComponentNotFoundException($"Component {request.ComponentId} has not been found");
            }

            if (component.Versions?.Count > 0)
            {
                return component.Versions.Select(version => Map(version)).ToArray();
            }

            return Enumerable.Empty<VersionDto>().ToArray();
        }

        private static VersionDto Map(Domain.Entities.Version version)
        {
            return new VersionDto(
                version.Id,
                version.ModifiedDate,
                version.Major,
                version.Minor,
                version.Patch,
                version.PreRelease,
                version.Description
            );
        }
    }
}
