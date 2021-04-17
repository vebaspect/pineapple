using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Użytkownik.
    /// </summary>
    public abstract class User : Entity
    {
        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; protected set;}

        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; protected set;}

        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; protected set;}

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; protected set;}

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; protected set;}

        /// <summary>
        /// Logi posiadane przez użytkownika.
        /// </summary>
        public List<Log> OwnedLogs { get; protected set;}

        /// <summary>
        /// Logi dotyczące użytkownika.
        /// </summary>
        public List<UserLog> EntityLogs { get; protected set;}

        protected User(Guid id)
            : base(id)
        {
        }
    }
}
