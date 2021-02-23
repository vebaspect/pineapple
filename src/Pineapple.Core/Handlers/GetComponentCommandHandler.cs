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
    public class GetComponentCommandHandler : RequestHandler<GetComponentCommand, Task<ComponentDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ComponentDto> Handle(GetComponentCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var product = await databaseContext
                .Products
                .Include(product => product.Components)
                .ThenInclude(component => component.ComponentType)
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

            return Map(component);
        }

        private static ComponentDto Map(Domain.Entities.Component component)
        {
            return new ComponentDto(component.Id, component.ModifiedDate, component.Name, component.Description, component.ComponentTypeId);
        }
    }
}
