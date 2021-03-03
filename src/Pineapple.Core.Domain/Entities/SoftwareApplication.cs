using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Oprogramowanie.
    /// </summary>
    public class SoftwareApplication : Entity
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; set; }
    }
}
