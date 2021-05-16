using System;
using System.Collections.Generic;

namespace Pineapple.Core.Dto.ImplementationsTree
{
    /// <summary>
    /// Drzewo wdrożeń - węzeł reprezentujący wdrożenie.
    /// </summary>
    public class ImplementationNodeDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Flaga określająca, czy wdrożenie zostało usunięte.
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

        /// <summary>
        /// Węzły reprezentujące środowiska.
        /// </summary>
        public List<EnvironmentNodeDto> Environments { get; set; }

        public ImplementationNodeDto()
        {
            Environments = new List<EnvironmentNodeDto>();
        }
    }
}
