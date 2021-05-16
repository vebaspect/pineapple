using System;

namespace Pineapple.Core.Dto.ImplementationsTree
{
    /// <summary>
    /// Drzewo wdrożeń - węzeł reprezentujący środowisko.
    /// </summary>
    public class EnvironmentNodeDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Flaga określająca, czy środowisko zostało usunięte.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }
    }
}
