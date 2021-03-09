using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateComponentCommandHandler : RequestHandler<CreateComponentCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateComponentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateComponentCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentId = Guid.NewGuid();

            var component = Domain.Entities.Component.Create(componentId, request.Name, request.Description, request.ProductId, request.ComponentTypeId);

            await databaseContext.Components.AddAsync(component).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return componentId;
        }
    }
}
