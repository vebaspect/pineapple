using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetCoordinatorsCommand : IRequest<Task<CoordinatorDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        public GetCoordinatorsCommand(Guid implementationId)
        {
            ImplementationId = implementationId;
        }
    }
}
