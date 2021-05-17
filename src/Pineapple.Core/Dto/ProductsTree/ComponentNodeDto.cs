using System;

namespace Pineapple.Core.Dto.ProductsTree
{
    /// <summary>
    /// Drzewo produktów - węzeł reprezentujący komponent.
    /// </summary>
    public class ComponentNodeDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Flaga określająca, czy komponent został usunięty.
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
