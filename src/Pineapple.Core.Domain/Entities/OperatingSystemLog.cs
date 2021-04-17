using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący systemu operacyjnego.
    /// </summary>
    public sealed class OperatingSystemLog : Log
    {
        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; }

        /// <summary>
        /// System operacyjny.
        /// </summary>
        public OperatingSystem OperatingSystem { get; }

        private OperatingSystemLog(Guid id, string category, Guid ownerId, Guid operatingSystemId)
        {
            Id = id;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            IsDeleted = false;
            Category = category;
            OwnerId = ownerId;
            OperatingSystemId = operatingSystemId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static OperatingSystemLog Create(Guid id, string category, Guid ownerId, Guid operatingSystemId)
        {
            return new OperatingSystemLog(id, category, ownerId, operatingSystemId);
        }
    }
}
