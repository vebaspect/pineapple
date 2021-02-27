using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetUserCommand : IRequest<Task<UserDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public Guid UserId { get; }

        public GetUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
