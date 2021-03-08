using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Menedżer.
    /// </summary>
    public sealed class Manager : User
    {
        private Manager(Guid id, string fullName, string login, string phone, string email)
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
        /// Stwórz menedżera.
        /// </summary>
        public static Manager Create(Guid id, string fullName, string login, string phone, string email)
        {
            return new Manager(id, fullName, login, phone, email);
        }
    }
}
