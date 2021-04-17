using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący wersji komponentu.
    /// </summary>
    public sealed class ComponentVersionLog : Log
    {
        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        /// <summary>
        /// Wersja komponentu.
        /// </summary>
        public ComponentVersion ComponentVersion { get; }

        private ComponentVersionLog(Guid id, string category, Guid ownerId, Guid componentVersionId)
        {
            Id = id;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            IsDeleted = false;
            Category = category;
            OwnerId = ownerId;
            ComponentVersionId = componentVersionId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ComponentVersionLog Create(Guid id, string category, Guid ownerId, Guid componentVersionId)
        {
            return new ComponentVersionLog(id, category, ownerId, componentVersionId);
        }
    }
}
