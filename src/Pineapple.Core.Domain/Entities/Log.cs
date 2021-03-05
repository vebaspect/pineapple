using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log.
    /// </summary>
    public abstract class Log : Entity
    {
        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Kategoria.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Użytkownik.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }
    }
}
