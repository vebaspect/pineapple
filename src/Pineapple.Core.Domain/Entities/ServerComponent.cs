using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Komponent zainstalowany na serwerze.
    /// </summary>
    public class ServerComponent
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Serwer.
        /// </summary>
        public Server Server { get; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        /// <summary>
        /// Wersja komponentu.
        /// </summary>
        public ComponentVersion ComponentVersion { get; }

        public ServerComponent(Guid serverId, Guid componentVersionId)
        {
            Id = Guid.NewGuid();
            ServerId = serverId;
            ComponentVersionId = componentVersionId;
        }
    }
}
