using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący typu komponentu.
    /// </summary>
    public sealed class ComponentTypeLog : Log
    {
        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        /// <summary>
        /// Typ komponentu.
        /// </summary>
        public ComponentType ComponentType { get; }

        private ComponentTypeLog(Guid id, string category, Guid ownerId, Guid componentTypeId)
            : base(id)
        {
            Category = category;
            OwnerId = ownerId;
            ComponentTypeId = componentTypeId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ComponentTypeLog Create(Guid id, string category, Guid ownerId, Guid componentTypeId)
        {
            return new ComponentTypeLog(id, category, ownerId, componentTypeId);
        }
    }
}
