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
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; }

        /// <summary>
        /// Flaga określająca, czy komponent został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Repozytorium kodu źródłowego (adres URL).
        /// </summary>
        public string SourceCodeRepositoryUrl { get; }

        /// <summary>
        /// Repozytorium paczek (ścieżka).
        /// </summary>
        public string PackagesRepositoryPath { get; }

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

        /// <summary>
        /// Identyfikator aktualnej wersji komponentu.
        /// </summary>
        public Guid? ActualComponentVersionId { get; }

        /// <summary>
        /// Numer aktualnej wersji komponentu.
        /// </summary>
        public string ActualComponentVersionNumber { get; }

        public ComponentDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string name, string sourceCodeRepositoryUrl, string packagesRepositoryPath, string description, Guid componentTypeId, string componentTypeName, Guid? actualComponentVersionId, string actualComponentVersionNumber)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Name = name;
            SourceCodeRepositoryUrl = sourceCodeRepositoryUrl;
            PackagesRepositoryPath = packagesRepositoryPath;
            Description = description;
            ComponentTypeId = componentTypeId;
            ComponentTypeName = componentTypeName;
            ActualComponentVersionId = actualComponentVersionId;
            ActualComponentVersionNumber = actualComponentVersionNumber;
        }
    }
}
