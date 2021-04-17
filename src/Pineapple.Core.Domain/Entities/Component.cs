using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

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
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
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
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }
            if (productId == Guid.Empty)
            {
                throw new ValueRequiredValidationException(nameof(productId));
            }
            if (componentTypeId == Guid.Empty)
            {
                throw new ValueRequiredValidationException(nameof(componentTypeId));
            }

            return new Component(id, name, description, productId, componentTypeId);
        }
    }
}
