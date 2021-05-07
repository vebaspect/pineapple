using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Komponent zainstalowany na serwerze.
    /// </summary>
    public class ServerComponentDto : IDto
    {
        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        public ServerComponentDto(Guid componentId)
        {
            ComponentId = componentId;
        }
    }
}
