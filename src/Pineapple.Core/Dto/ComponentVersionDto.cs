using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Wersja komponentu.
    /// </summary>
    public class ComponentVersionDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; }

        /// <summary>
        /// Flaga określająca, czy wersja komponentu została usunięta.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Rodzaj.
        /// </summary>
        public string Kind { get; }

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

        public ComponentVersionDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string kind, int major, int minor, int patch, string suffix, string description)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Kind = kind;
            Major = major;
            Minor = minor;
            Patch = patch;
            Suffix = suffix;
            Description = description;
        }
    }
}
