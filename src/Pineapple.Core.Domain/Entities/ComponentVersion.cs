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
        public int Major { get; }

        /// <summary>
        /// Minor.
        /// </summary>
        public int Minor { get; }

        /// <summary>
        /// Patch.
        /// </summary>
        public int Patch { get; }

        /// <summary>
        /// Wydanie przedpremierowe.
        /// </summary>
        public string PreRelease { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        /// <summary>
        /// Komponent.
        /// </summary>
        public Component Component { get; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; }

        /// <summary>
        /// Logi dotyczące komponentu.
        /// </summary>
        public List<ComponentVersionLog> EntityLogs { get; }

        private ComponentVersion(Guid id, int major, int minor, int patch, string preRelease, string description, Guid componentId)
        {
            Id = id;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
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

        /// <summary>
        /// Zwróć numer wersji komponentu w postaci sformatowanej (zgodnej z Semantic Versioning).
        /// </summary>
        public string GetFormattedNumber()
        {
            if (string.IsNullOrEmpty(PreRelease))
            {
                return $"{Major}.{Minor}.{Patch}";
            }

            return $"{Major}.{Minor}.{Patch}-{PreRelease}";
        }
    }
}
