using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący komponentu.
    /// </summary>
    public sealed class ComponentLog : Log
    {
        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        /// <summary>
        /// Komponent.
        /// </summary>
        public Component Component { get; }

        private ComponentLog(Guid id, string category, Guid ownerId, Guid componentId)
            : base(id)
        {
            Category = category;
            OwnerId = ownerId;
            ComponentId = componentId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ComponentLog Create(Guid id, string category, Guid ownerId, Guid componentId)
        {
            return new ComponentLog(id, category, ownerId, componentId);
        }
    }
}
