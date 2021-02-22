using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetCoordinatorCommand : IRequest<Task<CoordinatorDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Identyfikator koordynatora.
        /// </summary>
        public Guid CoordinatorId { get; }

        public GetCoordinatorCommand(Guid implementationId, Guid coordinatorId)
        {
            ImplementationId = implementationId;
            CoordinatorId = coordinatorId;
        }
    }
}
