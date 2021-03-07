using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Log.
    /// </summary>
    public class LogDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModifiedDate { get; }

        /// <summary>
        /// Flaga określająca, czy log został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Kategoria.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Identyfikator właściciela.
        /// </summary>
        public Guid OwnerId { get; }

        /// <summary>
        /// Imię i nazwisko właściciela.
        /// </summary>
        public string OwnerFullName { get; }

        /// <summary>
        /// Identyfikator encji.
        /// </summary>
        public Guid EntityId { get; }

        /// <summary>
        /// Nazwa encji.
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public LogDto(Guid id, DateTime modifiedDate, bool isDeleted, string type, string category, Guid ownerId, string ownerFullName, Guid entityId, string entityName, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            IsDeleted = isDeleted;
            Type = type;
            Category = category;
            OwnerId = ownerId;
            OwnerFullName = ownerFullName;
            EntityId = entityId;
            EntityName = entityName;
            Description = description;
        }
    }
}
