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
        public Guid Id { get; protected set; }

        /// <summary>
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; protected set; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; protected set; }

        /// <summary>
        /// Flaga określająca, czy encja została usunięta.
        /// </summary>
        public bool IsDeleted { get; protected set; }

        protected Entity(Guid id)
        {
            Id = id;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            IsDeleted = false;
        }

        /// <summary>
        /// Oznacz encję jako usuniętą.
        /// </summary>
        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity entity)
            {
                return false;
            }

            return Id == entity.Id;
        }
    }
}
