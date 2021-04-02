using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Produkt.
    /// </summary>
    public sealed class Product : Entity
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
        /// Komponenty.
        /// </summary>
        public List<Component> Components { get; }

        /// <summary>
        /// Logi dotyczące produktu.
        /// </summary>
        public List<ProductLog> EntityLogs { get; }

        private Product(Guid id, string name, string description)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Stwórz produkt.
        /// </summary>
        public static Product Create(Guid id, string name, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }

            return new Product(id, name, description);
        }
    }
}
