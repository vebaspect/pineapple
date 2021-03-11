using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        public GetComponentLogsCommand(Guid componentId)
        {
            ComponentId = componentId;
        }
    }
}
