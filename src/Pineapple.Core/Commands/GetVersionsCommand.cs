using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetVersionsCommand : IRequest<Task<VersionDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        public GetVersionsCommand(Guid productId, Guid componentId)
        {
            ProductId = productId;
            ComponentId = componentId;
        }
    }
}
