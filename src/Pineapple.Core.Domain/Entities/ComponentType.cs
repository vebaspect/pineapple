using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Typ komponentu.
    /// </summary>
    public sealed class ComponentType : Entity
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Komponenty.
        /// </summary>
        public List<Component> Components { get; }

        /// <summary>
        /// Logi dotyczące typu komponentu.
        /// </summary>
        public List<ComponentTypeLog> EntityLogs { get; }

        private ComponentType(Guid id, string name, string symbol, string description)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Symbol = symbol;
            Description = description;
        }

        /// <summary>
        /// Stwórz typ komponentu.
        /// </summary>
        public static ComponentType Create(Guid id, string name, string symbol, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ValueRequiredValidationException(nameof(symbol));
            }

            return new ComponentType(id, name, symbol, description);
        }
    }
}
