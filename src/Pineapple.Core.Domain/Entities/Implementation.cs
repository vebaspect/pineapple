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
        public string Name { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Środowiska.
        /// </summary>
        public List<Environment> Environments { get; set; }

        /// <summary>
        /// Koordynatorzy.
        /// </summary>
        public List<Coordinator> Coordinators { get; set; }

        /// <summary>
        /// Logi dotyczące wdrożenia.
        /// </summary>
        public List<ImplementationLog> EntityLogs { get; set; }

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
