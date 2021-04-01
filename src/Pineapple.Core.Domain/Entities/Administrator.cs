using System;
using Pineapple.Core.Domain.Exceptions;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Administrator.
    /// </summary>
    public sealed class Administrator : User
    {
        private Administrator(Guid id, string fullName, string login, string phone, string email)
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
        /// Stwórz administratora.
        /// </summary>
        public static Administrator Create(Guid id, string fullName, string login, string phone, string email)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ValueRequiredValidationException(nameof(fullName));
            }
            if (string.IsNullOrEmpty(login))
            {
                throw new ValueRequiredValidationException(nameof(login));
            }

            return new Administrator(id, fullName, login, phone, email);
        }
    }
}
