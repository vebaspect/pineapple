using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetProductCommandHandler : RequestHandler<GetProductCommand, Task<ProductDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetProductCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ProductDto> Handle(GetProductCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var product = await databaseContext
                .Products
                .FirstOrDefaultAsync(product => product.Id == request.ProductId)
                .ConfigureAwait(false);

            if (product is null)
            {
                throw new Exception($"Product {request.ProductId} not exist");
            }

            return Map(product);
        }

        private static ProductDto Map(Domain.Entities.Product product)
        {
            return new ProductDto(product.Id, product.Name, product.Description);
        }
    }
}
