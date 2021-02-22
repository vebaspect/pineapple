using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateProductCommandHandler : RequestHandler<CreateProductCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateProductCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateProductCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var productId = Guid.NewGuid();

            var product = new Domain.Entities.Product()
            {
                Id = productId,
                Name = request.Name,
                Description = request.Description
            };

            await databaseContext.Products.AddAsync(product).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return productId;
        }
    }
}
