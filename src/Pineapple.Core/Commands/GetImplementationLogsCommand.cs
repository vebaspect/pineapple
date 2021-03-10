using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;
using System;

namespace Pineapple.Core.Commands
{
    public class GetImplementationLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        public GetImplementationLogsCommand(Guid implementationId)
        {
            ImplementationId = implementationId;
        }
    }
}
