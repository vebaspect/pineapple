using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentVersionCommand : IRequest<Task<ComponentVersionDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        public GetComponentVersionCommand(Guid productId, Guid componentId, Guid componentVersionId)
        {
            ProductId = productId;
            ComponentId = componentId;
            ComponentVersionId = componentVersionId;
        }
    }
}
