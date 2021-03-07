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

        /// <summary>
        /// Flaga określająca, czy encja została usunięta.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Oznacz encję jako usuniętą.
        /// </summary>
        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
