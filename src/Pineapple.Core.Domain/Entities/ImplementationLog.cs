using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący wdrożenia.
    /// </summary>
    public sealed class ImplementationLog : Log
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; set; }

        /// <summary>
        /// Wdrożenie.
        /// </summary>
        public Implementation Implementation { get; set; }

        private ImplementationLog(Guid id, string category, Guid ownerId, Guid implementationId)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Category = category;
            OwnerId = ownerId;
            ImplementationId = implementationId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ImplementationLog Create(Guid id, string category, Guid ownerId, Guid implementationId)
        {
            return new ImplementationLog(id, category, ownerId, implementationId);
        }
    }
}
