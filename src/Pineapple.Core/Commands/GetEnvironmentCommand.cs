using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetEnvironmentCommand : IRequest<Task<EnvironmentDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        public GetEnvironmentCommand(Guid implementationId, Guid environmentId)
        {
            ImplementationId = implementationId;
            EnvironmentId = environmentId;
        }
    }
}
