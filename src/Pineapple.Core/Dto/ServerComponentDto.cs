using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Komponent zainstalowany na serwerze.
    /// </summary>
    public class ServerComponentDto : IDto
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

        public ServerComponentDto(Guid productId, Guid componentId, Guid componentVersionId)
        {
            ProductId = productId;
            ComponentId = componentId;
            ComponentVersionId = componentVersionId;
        }
    }
}
