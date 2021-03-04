using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateImplementationCommandHandler : RequestHandler<CreateImplementationCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateImplementationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateImplementationCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementationId = Guid.NewGuid();

            var implementation = new Domain.Entities.Implementation()
            {
                Id = implementationId,
                ModifiedDate = DateTime.Now,
                Name = request.Name,
                Description = request.Description
            };

            await databaseContext.Implementations.AddAsync(implementation).ConfigureAwait(false);

            var implementationLogId = Guid.NewGuid();

            var implementationLog = new Domain.Entities.ImplementationLog()
            {
                Id = implementationLogId,
                ModifiedDate = DateTime.Now,
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"), // Mock!
                ImplementationId = implementationId
            };

            await databaseContext.Logs.AddAsync(implementationLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return implementationId;
        }
    }
}
