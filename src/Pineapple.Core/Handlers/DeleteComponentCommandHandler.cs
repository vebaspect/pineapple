using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class DeleteComponentCommandHandler : AsyncRequestHandler<DeleteComponentCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteComponentCommand request, CancellationToken cancellationToken)
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

            var component = product
                .Components?
                .FirstOrDefault(component => component.Id == request.ComponentId);

            if (component is null)
            {
                throw new ComponentNotFoundException($"Component {request.ComponentId} has not been found");
            }

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

            if (!component.IsDeleted)
            {
                component.SetAsDeleted();

                var componentLogId = Guid.NewGuid();

                var componentLog = Domain.Entities.ComponentLog.Create(componentLogId, AvailableLogCategories.RemoveEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), component.Id); // Mock!

                await databaseContext.Logs.AddAsync(componentLog, cancellationToken).ConfigureAwait(false);
            }

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
