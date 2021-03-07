using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący użytkownika.
    /// </summary>
    public class UserLog : Log
    {
        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Użytkownik.
        /// </summary>
        public User User { get; set; }
    }
}
