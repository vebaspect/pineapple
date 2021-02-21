using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetEnvironmentsCommand : IRequest<Task<EnvironmentDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        public GetEnvironmentsCommand(Guid implementationId)
        {
            ImplementationId = implementationId;
        }
    }
}
