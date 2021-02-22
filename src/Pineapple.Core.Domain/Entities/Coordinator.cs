using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Koordynator.
    /// </summary>
    public class Coordinator : Entity
    {
        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; set; }

        /// <summary>
        /// Wdrożenie.
        /// </summary>
        public Implementation Implementation { get; set; }
    }
}
