using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

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
                FullName = request.FullName,
                Login = request.Login,
                Phone = request.Phone,
                Email = request.Email,
            };

            await databaseContext.Users.AddAsync(@operator).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return operatorId;
        }
    }
}
