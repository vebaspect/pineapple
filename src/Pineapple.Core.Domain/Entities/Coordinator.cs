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

        private Coordinator(Guid id, string fullName, string phone, string email, Guid implementationId)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
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
