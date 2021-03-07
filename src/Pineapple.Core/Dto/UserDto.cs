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
        /// Flaga określająca, czy użytkownik został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; }

        public UserDto(Guid id, DateTime modifiedDate, bool isDeleted, string type, string fullName, string login, string phone, string email)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            IsDeleted = isDeleted;
            Type = type;
            FullName = fullName;
            Login = login;
            Phone = phone;
            Email = email;
        }
    }
}
