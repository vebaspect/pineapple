using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Koordynator.
    /// </summary>
    public sealed class Coordinator : Entity
    {
        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Wdrożenie.
        /// </summary>
        public Implementation Implementation { get; }

        private Coordinator(Guid id, string fullName, string phone, string email, Guid implementationId)
            : base(id)
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
            ImplementationId = implementationId;
        }

        /// <summary>
        /// Stwórz koordynatora.
        /// </summary>
        public static Coordinator Create(Guid id, string fullName, string phone, string email, Guid implementationId)
        {
            return new Coordinator(id, fullName, phone, email, implementationId);
        }
    }
}
