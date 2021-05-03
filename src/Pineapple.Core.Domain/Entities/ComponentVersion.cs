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
        /// Data wydania.
        /// </summary>
        public DateTime ReleaseDate { get; }

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
        /// Przyrostek.
        /// </summary>
        public string Suffix { get; }

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
        /// Serwery na których jest zainstalowana.
        /// </summary>
        public List<ServerComponent> Servers { get; }

        /// <summary>
        /// Logi dotyczące wersji komponentu.
        /// </summary>
        public List<ComponentVersionLog> EntityLogs { get; }

        private ComponentVersion(Guid id, DateTime releaseDate, int major, int minor, int patch, string suffix, string description, Guid componentId)
            : base(id)
        {
            ReleaseDate = releaseDate;
            Major = major;
            Minor = minor;
            Patch = patch;
            Suffix = suffix;
            Description = description;
            ComponentId = componentId;
        }

        /// <summary>
        /// Stwórz wersję komponentu.
        /// </summary>
        public static ComponentVersion Create(Guid id, DateTime releaseDate, int major, int minor, int patch, string suffix, string description, Guid componentId)
        {
            return new ComponentVersion(id, releaseDate, major, minor, patch, suffix, description, componentId);
        }

        /// <summary>
        /// Zwróć numer wersji komponentu (zgodnej z Semantic Versioning).
        /// </summary>
        public string GetFormattedNumber()
        {
            if (string.IsNullOrEmpty(Suffix))
            {
                return $"{Major}.{Minor}.{Patch}";
            }

            return $"{Major}.{Minor}.{Patch}-{Suffix}";
        }

        /// <summary>
        /// Zwróć rodzaj wersji komponentu.
        /// </summary>
        public string GetKind()
        {
            if (!string.IsNullOrEmpty(Suffix))
            {
                return AvailableComponentVersionKinds.PreRelease;
            }

            if (Patch > 0)
            {
                return AvailableComponentVersionKinds.Patch;
            }

            return AvailableComponentVersionKinds.Release;
        }
    }
}
