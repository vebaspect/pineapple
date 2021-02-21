using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetImplementationCommand : IRequest<Task<ImplementationDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        public GetImplementationCommand(Guid implementationId)
        {
            ImplementationId = implementationId;
        }
    }
}
