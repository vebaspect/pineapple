using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentVersionsCommand : IRequest<Task<ComponentVersionDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        public GetComponentVersionsCommand(Guid productId, Guid componentId)
        {
            ProductId = productId;
            ComponentId = componentId;
        }
    }
}
