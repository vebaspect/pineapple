using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Środowisko.
    /// </summary>
    public class Environment : Entity
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
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; set; }

        /// <summary>
        /// Wdrożenie.
        /// </summary>
        public Implementation Implementation { get; set; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; set; }

        /// <summary>
        /// Identyfikator wdrożeniowca.
        /// </summary>
        public Guid OperatorId { get; set; }

        /// <summary>
        /// Wdrożeniowiec.
        /// </summary>
        public Operator Operator { get; set; }
    }
}
