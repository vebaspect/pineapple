using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Encja.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
