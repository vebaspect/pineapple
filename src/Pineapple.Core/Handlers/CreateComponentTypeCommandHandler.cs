using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateComponentTypeCommandHandler : RequestHandler<CreateComponentTypeCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateComponentTypeCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateComponentTypeCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentTypeId = Guid.NewGuid();

            var componentType = new Domain.Entities.ComponentType()
            {
                Id = componentTypeId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Name = request.Name,
                Symbol = request.Symbol,
                Description = request.Description,
            };

            await databaseContext.ComponentTypes.AddAsync(componentType).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return componentTypeId;
        }
    }
}
