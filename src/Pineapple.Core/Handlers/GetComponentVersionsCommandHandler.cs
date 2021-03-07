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
    public class GetComponentVersionsCommandHandler : RequestHandler<GetComponentVersionsCommand, Task<ComponentVersionDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentVersionsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ComponentVersionDto[]> Handle(GetComponentVersionsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var product = await databaseContext
                .Products
                .Include(product => product.Components)
                .ThenInclude(component => component.ComponentVersions)
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

            if (component.ComponentVersions?.Count > 0)
            {
                return component.ComponentVersions.Select(componentVersion => Map(componentVersion)).ToArray();
            }

            return Enumerable.Empty<ComponentVersionDto>().ToArray();
        }

        private static ComponentVersionDto Map(Domain.Entities.ComponentVersion componentVersion)
        {
            return new ComponentVersionDto(
                componentVersion.Id,
                componentVersion.ModifiedDate,
                componentVersion.IsDeleted,
                componentVersion.Major,
                componentVersion.Minor,
                componentVersion.Patch,
                componentVersion.PreRelease,
                componentVersion.Description
            );
        }
    }
}
