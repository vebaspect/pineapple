using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;

namespace Pineapple.Core.Handler
{
    public class CreateDeveloperCommandHandler : RequestHandler<CreateDeveloperCommand, Task<Guid>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public CreateDeveloperCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Guid> Handle(CreateDeveloperCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var developerId = Guid.NewGuid();

            var developer = new Domain.Entities.Developer()
            {
                Id = developerId,
                ModifiedDate = DateTime.Now,
                FullName = request.FullName,
                Login = request.Login,
                Phone = request.Phone,
                Email = request.Email,
            };

            await databaseContext.Users.AddAsync(developer).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return developerId;
        }
    }
}
