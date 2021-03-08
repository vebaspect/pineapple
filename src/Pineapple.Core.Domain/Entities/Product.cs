using System;
using System.Collections.Generic;

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
        public string Name { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Komponenty.
        /// </summary>
        public List<Component> Components { get; set; }

        /// <summary>
        /// Logi dotyczące produktu.
        /// </summary>
        public List<ProductLog> EntityLogs { get; set; }

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
            return new Product(id, name, description);
        }
    }
}
