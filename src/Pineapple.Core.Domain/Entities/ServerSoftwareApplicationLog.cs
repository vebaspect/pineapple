using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący oprogramowania zainstalowanego na serwerze.
    /// </summary>
    public sealed class ServerSoftwareApplicationLog : ServerLog
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid ServerSoftwareApplicationId { get; private set; }

        /// <summary>
        /// Oprogramowanie.
        /// </summary>
        public SoftwareApplication ServerSoftwareApplication { get; internal set; }

        private ServerSoftwareApplicationLog(Guid id, string category, Guid ownerId, Guid serverId, Guid serverSoftwareApplicationId)
            : base(id, category, ownerId, serverId)
        {
            ServerSoftwareApplicationId = serverSoftwareApplicationId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ServerSoftwareApplicationLog Create(Guid id, string category, Guid ownerId, Guid serverId, Guid serverSoftwareApplicationId)
        {
            return new ServerSoftwareApplicationLog(id, category, ownerId, serverId, serverSoftwareApplicationId);
        }
    }
}
