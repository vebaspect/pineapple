using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

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
        /// Logi dotyczące wdrożenia.
        /// </summary>
        public List<ImplementationLog> EntityLogs { get; }

        private Implementation(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Stwórz wdrożenie.
        /// </summary>
        public static Implementation Create(Guid id, string name, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }

            return new Implementation(id, name, description);
        }
    }
}
