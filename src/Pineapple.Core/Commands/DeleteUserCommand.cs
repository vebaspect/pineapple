using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteUserCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public Guid UserId { get; }

        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
