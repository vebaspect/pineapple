using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteComponentVersionCommand : IRequest, ICommand
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

        public DeleteComponentVersionCommand(Guid productId, Guid componentId, Guid componentVersionId)
        {
            ProductId = productId;
            ComponentId = componentId;
            ComponentVersionId = componentVersionId;
        }
    }
}
