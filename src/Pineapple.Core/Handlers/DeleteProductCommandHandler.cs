using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteProductCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var product = await databaseContext
                .Products
                .Include(product => product.Components)
                .ThenInclude(component => component.ComponentVersions)
                .FirstOrDefaultAsync(product => product.Id == request.ProductId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (product is null)
            {
                throw new ProductNotFoundException($"Product {request.ProductId} has not been found");
            }

            if (product.Components?.Count > 0)
            {
                foreach (Domain.Entities.Component component in product.Components)
                {
                    if (!component.IsDeleted)
                    {
                        if (component.ComponentVersions?.Count > 0)
                        {
                            foreach (Domain.Entities.ComponentVersion componentVersion in component.ComponentVersions)
                            {
                                if (!componentVersion.IsDeleted)
                                {
                                    componentVersion.SetAsDeleted();

                                    var componentVersionLogId = Guid.NewGuid();

                                    var componentVersionLog = Domain.Entities.ComponentVersionLog.Create(componentVersionLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), componentVersion.Id); // Mock!

                                    await databaseContext.Logs.AddAsync(componentVersionLog, cancellationToken).ConfigureAwait(false);
                                }
                            }
                        }

                        component.SetAsDeleted();

                        var componentLogId = Guid.NewGuid();

                        var componentLog = Domain.Entities.ComponentLog.Create(componentLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), component.Id); // Mock!

                        await databaseContext.Logs.AddAsync(componentLog, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            product.SetAsDeleted();

            var productLogId = Guid.NewGuid();

            var productLog = Domain.Entities.ProductLog.Create(productLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), request.ProductId); // Mock!

            await databaseContext.Logs.AddAsync(productLog, cancellationToken).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
