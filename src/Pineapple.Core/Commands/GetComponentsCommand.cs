using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentsCommand : IRequest<Task<ComponentDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        public GetComponentsCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
