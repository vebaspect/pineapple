using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Pineapple.Core.Exceptions;

namespace Pineapple.Core.Handler
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public DeleteUserCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<Task> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var user = await databaseContext
                .Users
                .FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (user is null)
            {
                throw new UserNotFoundException($"User {request.UserId} has not been found");
            }

            databaseContext.Users.Remove(user);

            databaseContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
