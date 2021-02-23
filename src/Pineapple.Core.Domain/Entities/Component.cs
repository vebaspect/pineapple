using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Komponent.
    /// </summary>
    public class Component : Entity
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
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Produkt.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; set; }

        /// <summary>
        /// Typ.
        /// </summary>
        public ComponentType ComponentType { get; set; }

        /// <summary>
        /// Wersje.
        /// </summary>
        public List<Version> Versions { get; set; }
    }
}
