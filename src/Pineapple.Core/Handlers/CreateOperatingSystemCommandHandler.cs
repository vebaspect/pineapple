using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateOperatingSystemCommandHandler : RequestHandler<CreateOperatingSystemCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateOperatingSystemCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateOperatingSystemCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var operatingSystemId = Guid.NewGuid();

            var operatingSystem = new Domain.Entities.OperatingSystem()
            {
                Id = operatingSystemId,
                ModifiedDate = DateTime.Now,
                Name = request.Name,
                Symbol = request.Symbol,
                Description = request.Description,
            };

            await databaseContext.OperatingSystems.AddAsync(operatingSystem).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return operatingSystemId;
        }
    }
}
