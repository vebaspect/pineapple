using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Użytkownik.
    /// </summary>
    public class UserDto : IDto
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
        public string Type { get; set; }

        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; }

        public UserDto(Guid id, DateTime modifiedDate, string type, string fullName, string login, string phone, string email)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Type = type;
            FullName = fullName;
            Login = login;
            Phone = phone;
            Email = email;
        }
    }
}
