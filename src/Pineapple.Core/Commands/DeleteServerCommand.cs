using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteServerCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        public DeleteServerCommand(Guid implementationId, Guid environmentId, Guid serverId)
        {
            ImplementationId = implementationId;
            EnvironmentId = environmentId;
            ServerId = serverId;
        }
    }
}
