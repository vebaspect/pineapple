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
    public class GetComponentsCommandHandler : RequestHandler<GetComponentsCommand, Task<ComponentDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ComponentDto[]> Handle(GetComponentsCommand request)
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
                throw new ProductNotFoundException($"Product {request.ProductId} has not been found");
            }

            if (product.Components?.Count > 0)
            {
                return product.Components.Select(component => Map(component)).ToArray();
            }

            return Enumerable.Empty<ComponentDto>().ToArray();
        }

        private static ComponentDto Map(Domain.Entities.Component component)
        {
            return new ComponentDto(
                component.Id,
                component.ModifiedDate,
                component.Name,
                component.Description,
                component.ComponentTypeId,
                component.ComponentType.Name
            );
        }
    }
}
