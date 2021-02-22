using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetVersionCommand : IRequest<Task<VersionDto>>, ICommand
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
        /// Identyfikator wersji.
        /// </summary>
        public Guid VersionId { get; }

        public GetVersionCommand(Guid productId, Guid componentId, Guid versionId)
        {
            ProductId = productId;
            ComponentId = componentId;
            VersionId = versionId;
        }
    }
}
