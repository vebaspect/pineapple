using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący komponentu zainstalowanego na serwerze.
    /// </summary>
    public sealed class ServerComponentLog : ServerLog
    {
        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ServerComponentVersionId { get; protected set; }

        /// <summary>
        /// Wersja komponentu.
        /// </summary>
        public ComponentVersion ServerComponentVersion { get; protected set; }

        private ServerComponentLog(Guid id, string category, Guid ownerId, Guid serverId, Guid serverComponentVersionId)
            : base(id, category, ownerId, serverId)
        {
            ServerComponentVersionId = serverComponentVersionId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ServerComponentLog Create(Guid id, string category, Guid ownerId, Guid serverId, Guid serverComponentVersionId)
        {
            return new ServerComponentLog(id, category, ownerId, serverId, serverComponentVersionId);
        }
    }
}
