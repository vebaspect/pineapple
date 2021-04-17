using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący środowiska.
    /// </summary>
    public sealed class EnvironmentLog : Log
    {
        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        /// <summary>
        /// Środowisko.
        /// </summary>
        public Environment Environment { get; }

        private EnvironmentLog(Guid id, string category, Guid ownerId, Guid environmentId)
            : base(id)
        {
            Category = category;
            OwnerId = ownerId;
            EnvironmentId = environmentId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static EnvironmentLog Create(Guid id, string category, Guid ownerId, Guid environmentId)
        {
            return new EnvironmentLog(id, category, ownerId, environmentId);
        }
    }
}
