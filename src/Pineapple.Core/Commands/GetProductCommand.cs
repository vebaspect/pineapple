using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetProductCommand : IRequest<Task<ProductDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        public GetProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
