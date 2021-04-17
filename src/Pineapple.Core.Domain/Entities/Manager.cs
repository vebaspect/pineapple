using System;
using Pineapple.Core.Domain.Exceptions;

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
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
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
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ValueRequiredValidationException(nameof(fullName));
            }
            if (string.IsNullOrEmpty(login))
            {
                throw new ValueRequiredValidationException(nameof(login));
            }

            return new Manager(id, fullName, login, phone, email);
        }
    }
}
