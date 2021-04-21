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
        /// Identyfikator menedżera.
        /// </summary>
        public Guid ManagerId { get; }

        /// <summary>
        /// Menedżer.
        /// </summary>
        public Manager Manager { get; }

        /// <summary>
        /// Środowiska.
        /// </summary>
        public List<Environment> Environments { get; }

        /// <summary>
        /// Logi dotyczące wdrożenia.
        /// </summary>
        public List<ImplementationLog> EntityLogs { get; }

        private Implementation(Guid id, string name, string description, Guid managerId)
            : base(id)
        {
            Name = name;
            Description = description;
            ManagerId = managerId;
        }

        /// <summary>
        /// Stwórz wdrożenie.
        /// </summary>
        public static Implementation Create(Guid id, string name, string description, Guid managerId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }
            if (managerId == Guid.Empty)
            {
                throw new ValueRequiredValidationException(nameof(managerId));
            }

            return new Implementation(id, name, description, managerId);
        }
    }
}
