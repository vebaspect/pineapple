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

        public ComponentDto(Guid id, DateTime modifiedDate, string name, string description, Guid componentTypeId, string componentTypeName)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Name = name;
            Description = description;
            ComponentTypeId = componentTypeId;
            ComponentTypeName = componentTypeName;
        }
    }
}
