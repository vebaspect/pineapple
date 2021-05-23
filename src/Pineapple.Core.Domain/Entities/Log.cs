using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log.
    /// </summary>
    public abstract class Log : Entity
    {
        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// Kategoria.
        /// </summary>
        public string Category { get; protected set; }

        /// <summary>
        /// Identyfikator właściciela.
        /// </summary>
        public Guid OwnerId { get; protected set; }

        /// <summary>
        /// Właściciel.
        /// </summary>
        public User Owner { get; protected set; }

        protected Log(Guid id)
            : base(id)
        {
        }
    }
}
