using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class CreateManagerCommandHandler : RequestHandler<CreateManagerCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateManagerCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateManagerCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var managerId = Guid.NewGuid();

            var manager = Domain.Entities.Manager.Create(managerId, request.FullName, request.Login, request.Phone, request.Email);

            await databaseContext.Users.AddAsync(manager).ConfigureAwait(false);

            var userLogId = Guid.NewGuid();

            var userLog = new Domain.Entities.UserLog()
            {
                Id = userLogId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Category = AvailableLogCategories.AddEntity,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), // Mock!
                UserId = managerId
            };

            await databaseContext.Logs.AddAsync(userLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return managerId;
        }
    }
}
