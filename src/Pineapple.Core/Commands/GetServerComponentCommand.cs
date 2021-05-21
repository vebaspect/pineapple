using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetServerComponentCommand : IRequest<Task<ServerComponentDto>>, ICommand
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

        /// <summary>
        /// Identyfikator komponentu zainstalowanego na serwerze.
        /// </summary>
        public Guid ServerComponentId { get; }

        public GetServerComponentCommand(Guid implementationId, Guid environmentId, Guid serverId, Guid serverComponentId)
        {
            ImplementationId = implementationId;
            EnvironmentId = environmentId;
            ServerId = serverId;
            ServerComponentId = serverComponentId;
        }
    }
}
