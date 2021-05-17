using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto.ProductsTree;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetProductsTreeCommandHandler : RequestHandler<GetProductsTreeCommand, Task<ProductsTreeDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetProductsTreeCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ProductsTreeDto> Handle(GetProductsTreeCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var products = await databaseContext
                .Products
                .Include(product => product.Components)
                .ToListAsync()
                .ConfigureAwait(false);

            ProductsTreeDto productsTree = new();

            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    ProductNodeDto productNode = new()
                    {
                        Id = product.Id,
                        IsDeleted = product.IsDeleted,
                        Name = product.Name,
                        Description = product.Description
                    };

                    productsTree.Products.Add(productNode);

                    if (product.Components.Count > 0)
                    {
                        foreach (var component in product.Components)
                        {
                            ComponentNodeDto componentNode = new()
                            {
                                Id = component.Id,
                                IsDeleted = component.IsDeleted,
                                Name = component.Name,
                                Description = component.Description
                            };

                            productNode.Components.Add(componentNode);
                        }

                        productNode.Components = productNode.Components
                            .OrderBy((componentNode) => componentNode.Name)
                            .ToList();
                    }
                }

                productsTree.Products = productsTree.Products
                    .OrderBy((productNode) => productNode.Name)
                    .ToList();
            }

            return productsTree;
        }
    }
}
