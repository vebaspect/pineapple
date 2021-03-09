using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Komponent.
    /// </summary>
    public sealed class Component : Entity
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
        /// Typ komponentu.
        /// </summary>
        public ComponentType ComponentType { get; set; }

        /// <summary>
        /// Wersje komponentu.
        /// </summary>
        public List<ComponentVersion> ComponentVersions { get; set; }

        private Component(Guid id, string name, string description, Guid productId, Guid componentTypeId)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Description = description;
            ProductId = productId;
            ComponentTypeId = componentTypeId;
        }

        /// <summary>
        /// Stwórz komponent.
        /// </summary>
        public static Component Create(Guid id, string name, string description, Guid productId, Guid componentTypeId)
        {
            return new Component(id, name, description, productId, componentTypeId);
        }
    }
}
