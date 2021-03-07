using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Pineapple.Core.Domain;

namespace Pineapple.Core.Handler
{
    public class CreateOperatorCommandHandler : RequestHandler<CreateOperatorCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateOperatorCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateOperatorCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var operatorId = Guid.NewGuid();

            var @operator = new Domain.Entities.Operator()
            {
                Id = operatorId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                FullName = request.FullName,
                Login = request.Login,
                Phone = request.Phone,
                Email = request.Email,
            };

            await databaseContext.Users.AddAsync(@operator).ConfigureAwait(false);

            var userLogId = Guid.NewGuid();

            var userLog = new Domain.Entities.UserLog()
            {
                Id = userLogId,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                Category = AvailableLogCategories.AddEntity,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), // Mock!
                UserId = operatorId
            };

            await databaseContext.Logs.AddAsync(userLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return operatorId;
        }
    }
}
