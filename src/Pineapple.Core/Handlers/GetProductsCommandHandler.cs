
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
    public class GetProductsCommandHandler : RequestHandler<GetProductsCommand, Task<ProductDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetProductsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ProductDto[]> Handle(GetProductsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var products = await databaseContext
                .Products
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (products?.Length > 0)
            {
                return products.Select(product => Map(product)).ToArray();
            }

            return Enumerable.Empty<ProductDto>().ToArray();
        }

        private static ProductDto Map(Domain.Entities.Product product)
        {
            return new ProductDto(product.Id, product.Name, product.Description);
        }
    }
}
