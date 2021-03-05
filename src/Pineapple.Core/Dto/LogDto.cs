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
        /// Opis.
        /// </summary>
        public string Description { get; }

        public LogDto(Guid id, DateTime modifiedDate, string type, string category, Guid userId, string userFullName, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Type = type;
            Category = category;
            UserId = userId;
            UserFullName = userFullName;
            Description = description;
        }
    }
}
