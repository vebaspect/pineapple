using System;

namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Komponent.
    /// </summary>
    public class CreateComponentDto
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Repozytorium kodu źródłowego (adres URL).
        /// </summary>
        public string SourceCodeRepositoryUrl { get; set; }

        /// <summary>
        /// Repozytorium paczek (ścieżka).
        /// </summary>
        public string PackagesRepositoryPath { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; set; }
    }
}
