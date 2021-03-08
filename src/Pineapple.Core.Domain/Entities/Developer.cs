using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Programista.
    /// </summary>
    public sealed class Developer : User
    {
        private Developer(Guid id, string fullName, string login, string phone, string email)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            FullName = fullName;
            Login = login;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Stwórz programistę.
        /// </summary>
        public static Developer Create(Guid id, string fullName, string login, string phone, string email)
        {
            return new Developer(id, fullName, login, phone, email);
        }
    }
}
