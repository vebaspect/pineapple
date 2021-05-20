using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Pineapple.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

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

            var existingUser = await databaseContext
                .Users
                .FirstOrDefaultAsync(user => user.Login == request.Login)
                .ConfigureAwait(false);

            if (!(existingUser is null))
            {
                throw new UserAlreadyExistsException($"User {existingUser.Login} already exists");
            }

            var developerId = Guid.NewGuid();

            var developer = Domain.Entities.Developer.Create(developerId, request.FullName, request.Login, request.Phone, request.Email);

            await databaseContext.Users.AddAsync(developer).ConfigureAwait(false);

            var userLogId = Guid.NewGuid();

            var userLog = Domain.Entities.UserLog.Create(userLogId, AvailableLogCategories.CreateEntity, Guid.Parse("00000000-0000-0000-0000-000000000000"), developerId); // Mock!

            await databaseContext.Logs.AddAsync(userLog).ConfigureAwait(false);

            databaseContext.SaveChanges();

            return developerId;
        }
    }
}
