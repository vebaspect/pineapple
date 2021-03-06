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
        /// Typ.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Kategoria.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Imię i nazwisko użytkownika.
        /// </summary>
        public string UserFullName { get; }

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

        public LogDto(Guid id, DateTime modifiedDate, string type, string category, Guid userId, string userFullName, Guid entityId, string entityName, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Type = type;
            Category = category;
            UserId = userId;
            UserFullName = userFullName;
            EntityId = entityId;
            EntityName = entityName;
            Description = description;
        }
    }
}
