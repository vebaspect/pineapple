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
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Produkt.
        /// </summary>
        public Product Product { get; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        /// <summary>
        /// Typ komponentu.
        /// </summary>
        public ComponentType ComponentType { get; }

        /// <summary>
        /// Wersje komponentu.
        /// </summary>
        public List<ComponentVersion> ComponentVersions { get; }

        /// <summary>
        /// Logi dotyczące komponentu.
        /// </summary>
        public List<ComponentLog> EntityLogs { get; }

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
