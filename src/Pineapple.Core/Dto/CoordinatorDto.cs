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

        public CoordinatorDto(Guid id, string fullName, string phone, string email)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            Email = email;
        }
    }
}
