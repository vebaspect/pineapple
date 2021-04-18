using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteEnvironmentCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        public DeleteEnvironmentCommand(Guid implementationId, Guid environmentId)
        {
            ImplementationId = implementationId;
            EnvironmentId = environmentId;
        }
    }
}
