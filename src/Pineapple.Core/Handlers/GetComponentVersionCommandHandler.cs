using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetComponentVersionCommandHandler : RequestHandler<GetComponentVersionCommand, Task<ComponentVersionDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentVersionCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ComponentVersionDto> Handle(GetComponentVersionCommand request)
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

            var componentVersion = component
                .ComponentVersions?
                .FirstOrDefault(componentVersion => componentVersion.Id == request.ComponentVersionId);

            if (componentVersion is null)
            {
                throw new ComponentVersionNotFoundException($"ComponentVersion {request.ComponentVersionId} has not been found");
            }

            return componentVersion.ToDto();
        }
    }
}
