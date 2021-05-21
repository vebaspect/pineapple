using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetServerSoftwareApplicationCommand : IRequest<Task<ServerSoftwareApplicationDto>>, ICommand
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
        /// Identyfikator oprogramowania zainstalowanego na serwerze.
        /// </summary>
        public Guid ServerSoftwareApplicationId { get; }

        public GetServerSoftwareApplicationCommand(Guid implementationId, Guid environmentId, Guid serverId, Guid serverSoftwareApplicationId)
        {
            ImplementationId = implementationId;
            EnvironmentId = environmentId;
            ServerId = serverId;
            ServerSoftwareApplicationId = serverSoftwareApplicationId;
        }
    }
}
