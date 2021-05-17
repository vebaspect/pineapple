using System;
using System.Collections.Generic;

namespace Pineapple.Core.Dto.ProductsTree
{
    /// <summary>
    /// Drzewo produktów - węzeł reprezentujący produkt.
    /// </summary>
    public class ProductNodeDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Flaga określająca, czy produkt został usunięty.
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
        /// Węzły reprezentujące komponenty.
        /// </summary>
        public List<ComponentNodeDto> Components { get; set; }

        public ProductNodeDto()
        {
            Components = new List<ComponentNodeDto>();
        }
    }
}
