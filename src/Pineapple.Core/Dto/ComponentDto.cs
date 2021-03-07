using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Komponent.
    /// </summary>
    public class ComponentDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModifiedDate { get; }

        /// <summary>
        /// Flaga określająca, czy komponent został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        /// <summary>
        /// Nazwa typu komponentu.
        /// </summary>
        public string ComponentTypeName { get; }

        public ComponentDto(Guid id, DateTime modifiedDate, bool isDeleted, string name, string description, Guid componentTypeId, string componentTypeName)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            IsDeleted = isDeleted;
            Name = name;
            Description = description;
            ComponentTypeId = componentTypeId;
            ComponentTypeName = componentTypeName;
        }
    }
}
