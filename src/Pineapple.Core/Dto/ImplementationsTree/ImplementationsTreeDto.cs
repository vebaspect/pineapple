using System.Collections.Generic;

namespace Pineapple.Core.Dto.ImplementationsTree
{
    /// <summary>
    /// Drzewo wdrożeń.
    /// </summary>
    public class ImplementationsTreeDto
    {
        /// <summary>
        /// Węzły reprezentujące wdrożenia.
        /// </summary>
        public List<ImplementationNodeDto> Implementations { get; set; }

        public ImplementationsTreeDto()
        {
            Implementations = new List<ImplementationNodeDto>();
        }
    }
}
