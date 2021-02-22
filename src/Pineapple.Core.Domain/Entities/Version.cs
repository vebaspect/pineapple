using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Wersja.
    /// </summary>
    public class Version : Entity
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
    }
}