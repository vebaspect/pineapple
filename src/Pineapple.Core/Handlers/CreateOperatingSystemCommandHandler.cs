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

            var operatingSystem = Domain.Entities.OperatingSystem.Create(operatingSystemId, request.Name, request.Symbol, request.Description);

            await databaseContext.OperatingSystems.AddAsync(operatingSystem).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return operatingSystemId;
        }
    }
}
