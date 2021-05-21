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
        public Guid ComponentVersionId { get; private set; }

        /// <summary>
        /// Wersja komponentu.
        /// </summary>
        public ComponentVersion ComponentVersion { get; internal set; }

        public ServerComponent(Guid serverId, Guid componentVersionId)
        {
            Id = Guid.NewGuid();
            ServerId = serverId;
            ComponentVersionId = componentVersionId;
        }

        /// <summary>
        /// Zaktualizuj komponent.
        /// </summary>
        public void UpdateComponent(Guid componentVersionId)
        {
            ComponentVersionId = componentVersionId;
        }
    }
}
