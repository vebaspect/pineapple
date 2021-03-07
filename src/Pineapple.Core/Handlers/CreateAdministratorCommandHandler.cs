using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class CreateAdministratorCommandHandler : RequestHandler<CreateAdministratorCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateAdministratorCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateAdministratorCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var administratorId = Guid.NewGuid();

            var administrator = new Domain.Entities.Administrator()
            {
                Id = administratorId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                FullName = request.FullName,
                Login = request.Login,
                Phone = request.Phone,
                Email = request.Email,
            };

            await databaseContext.Users.AddAsync(administrator).ConfigureAwait(false);

            var userLogId = Guid.NewGuid();

            var userLog = new Domain.Entities.UserLog()
            {
                Id = userLogId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Category = AvailableLogCategories.AddEntity,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), // Mock!
                UserId = administratorId
            };

            await databaseContext.Logs.AddAsync(userLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return administratorId;
        }
    }
}
