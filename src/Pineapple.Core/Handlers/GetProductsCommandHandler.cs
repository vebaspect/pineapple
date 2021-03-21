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

            Domain.Entities.Product[] products = null;

            if (request.Count.HasValue)
            {
                products = await databaseContext
                    .Products
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                products = await databaseContext
                    .Products
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (products?.Length > 0)
            {
                return products.Select(product => product.ToDto()).ToArray();
            }

            return Enumerable.Empty<ProductDto>().ToArray();
        }
    }
}
