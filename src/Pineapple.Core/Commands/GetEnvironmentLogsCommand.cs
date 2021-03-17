using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetEnvironmentLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        public GetEnvironmentLogsCommand(Guid environmentId)
        {
            EnvironmentId = environmentId;
        }
    }
}
