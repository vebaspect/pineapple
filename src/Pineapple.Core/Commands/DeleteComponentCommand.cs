using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteComponentCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        public DeleteComponentCommand(Guid productId, Guid componentId)
        {
            ProductId = productId;
            ComponentId = componentId;
        }
    }
}
