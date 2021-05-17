using System.Collections.Generic;

namespace Pineapple.Core.Dto.ProductsTree
{
    /// <summary>
    /// Drzewo produktów.
    /// </summary>
    public class ProductsTreeDto
    {
        /// <summary>
        /// Węzły reprezentujące produkty.
        /// </summary>
        public List<ProductNodeDto> Products { get; set; }

        public ProductsTreeDto()
        {
            Products = new List<ProductNodeDto>();
        }
    }
}
