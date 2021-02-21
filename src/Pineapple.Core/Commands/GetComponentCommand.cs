using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentCommand : IRequest<Task<ComponentDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        public GetComponentCommand(Guid productId, Guid componentId)
        {
            ProductId = productId;
            ComponentId = componentId;
        }
    }
}
