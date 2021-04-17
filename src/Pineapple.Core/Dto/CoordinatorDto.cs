using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Koordynator.
    /// </summary>
    public class CoordinatorDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; }

        /// <summary>
        /// Flaga określająca, czy koordynator został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

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

        public CoordinatorDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string fullName, string phone, string email)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            FullName = fullName;
            Phone = phone;
            Email = email;
        }
    }
}
