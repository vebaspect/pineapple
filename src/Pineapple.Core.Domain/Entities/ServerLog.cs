using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący serwera.
    /// </summary>
    public sealed class ServerLog : Log
    {
        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Serwer.
        /// </summary>
        public Server Server { get; }

        private ServerLog(Guid id, string category, Guid ownerId, Guid serverId)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Category = category;
            OwnerId = ownerId;
            ServerId = serverId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ServerLog Create(Guid id, string category, Guid ownerId, Guid serverId)
        {
            return new ServerLog(id, category, ownerId, serverId);
        }
    }
}
