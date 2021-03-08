using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Pineapple.Core.Domain;

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

            var product = Domain.Entities.Product.Create(productId, request.Name, request.Description);

            await databaseContext.Products.AddAsync(product).ConfigureAwait(false);

            var productLogId = Guid.NewGuid();

            var productLog = new Domain.Entities.ProductLog()
            {
                Id = productLogId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Category = AvailableLogCategories.AddEntity,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), // Mock!
                ProductId = productId
            };

            await databaseContext.Logs.AddAsync(productLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return productId;
        }
    }
}
