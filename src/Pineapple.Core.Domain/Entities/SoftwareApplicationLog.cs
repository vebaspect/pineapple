using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący oprogramowania.
    /// </summary>
    public sealed class SoftwareApplicationLog : Log
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        /// <summary>
        /// Oprogramowanie.
        /// </summary>
        public SoftwareApplication SoftwareApplication { get; }

        private SoftwareApplicationLog(Guid id, string category, Guid ownerId, Guid softwareApplicationId)
            : base(id)
        {
            Category = category;
            OwnerId = ownerId;
            SoftwareApplicationId = softwareApplicationId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static SoftwareApplicationLog Create(Guid id, string category, Guid ownerId, Guid softwareApplicationId)
        {
            return new SoftwareApplicationLog(id, category, ownerId, softwareApplicationId);
        }
    }
}
