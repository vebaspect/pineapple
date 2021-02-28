using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Wdrożeniowiec.
    /// </summary>
    public class Operator : User
    {
        /// <summary>
        /// Środowiska.
        /// </summary>
        public List<Environment> Environments { get; set; }
    }
}
