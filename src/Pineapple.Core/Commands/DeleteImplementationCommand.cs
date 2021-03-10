using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteImplementationCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        public DeleteImplementationCommand(Guid implementationId)
        {
            ImplementationId = implementationId;
        }
    }
}
