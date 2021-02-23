using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Typ komponentu.
    /// </summary>
    public class ComponentType : Entity
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
        /// Komponenty.
        /// </summary>
        public List<Component> Components { get; set; }
    }
}
