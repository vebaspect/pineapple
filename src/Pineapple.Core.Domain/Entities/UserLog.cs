using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący użytkownika.
    /// </summary>
    public sealed class UserLog : Log
    {
        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Użytkownik.
        /// </summary>
        public User User { get; }

        private UserLog(Guid id, string category, Guid ownerId, Guid userId)
            : base(id)
        {
            Category = category;
            OwnerId = ownerId;
            UserId = userId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static UserLog Create(Guid id, string category, Guid ownerId, Guid userId)
        {
            return new UserLog(id, category, ownerId, userId);
        }
    }
}
