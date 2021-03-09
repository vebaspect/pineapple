using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Wersja komponentu.
    /// </summary>
    public sealed class ComponentVersion : Entity
    {
        /// <summary>
        /// Major.
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// Minor.
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// Patch.
        /// </summary>
        public int Patch { get; set; }

        /// <summary>
        /// Wydanie przedpremierowe.
        /// </summary>
        public string PreRelease { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Komponent.
        /// </summary>
        public Component Component { get; set; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; set; }

        private ComponentVersion(Guid id, int major, int minor, int patch, string preRelease, string description, Guid componentId)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Major = major;
            Minor = minor;
            Patch = patch;
            PreRelease = preRelease;
            Description = description;
            ComponentId = componentId;
        }

        /// <summary>
        /// Stwórz wersję komponentu.
        /// </summary>
        public static ComponentVersion Create(Guid id, int major, int minor, int patch, string preRelease, string description, Guid componentId)
        {
            return new ComponentVersion(id, major, minor, patch, preRelease, description, componentId);
        }
    }
}
