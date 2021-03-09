using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Wdrożenie.
    /// </summary>
    public sealed class Implementation : Entity
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Środowiska.
        /// </summary>
        public List<Environment> Environments { get; }

        /// <summary>
        /// Koordynatorzy.
        /// </summary>
        public List<Coordinator> Coordinators { get; }

        /// <summary>
        /// Logi dotyczące wdrożenia.
        /// </summary>
        public List<ImplementationLog> EntityLogs { get; }

        private Implementation(Guid id, string name, string description)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Stwórz wdrożenie.
        /// </summary>
        public static Implementation Create(Guid id, string name, string description)
        {
            return new Implementation(id, name, description);
        }
    }
}
