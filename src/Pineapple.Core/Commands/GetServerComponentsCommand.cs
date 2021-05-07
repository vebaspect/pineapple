using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetServerComponentsCommand : IRequest<Task<ServerComponentDto[]>>, ICommand
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

        public GetServerComponentsCommand(Guid implementationId, Guid environmentId, Guid serverId)
        {
            ImplementationId = implementationId;
            EnvironmentId = environmentId;
            ServerId = serverId;
        }
    }
}
