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

        public ComponentVersionDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, int major, int minor, int patch, string preRelease, string description)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Major = major;
            Minor = minor;
            Patch = patch;
            PreRelease = preRelease;
            Description = description;
        }
    }
}
