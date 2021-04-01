using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Wdrożeniowiec.
    /// </summary>
    public sealed class Operator : User
    {
        /// <summary>
        /// Środowiska.
        /// </summary>
        public List<Environment> Environments { get; }

        private Operator(Guid id, string fullName, string login, string phone, string email)
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
        /// Stwórz wdrożeniowca.
        /// </summary>
        public static Operator Create(Guid id, string fullName, string login, string phone, string email)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ValueRequiredValidationException(nameof(fullName));
            }
            if (string.IsNullOrEmpty(login))
            {
                throw new ValueRequiredValidationException(nameof(login));
            }

            return new Operator(id, fullName, login, phone, email);
        }
    }
}
