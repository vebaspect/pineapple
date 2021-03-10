using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteProductCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
