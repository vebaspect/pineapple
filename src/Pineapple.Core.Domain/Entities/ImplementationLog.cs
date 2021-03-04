using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący wdrożenia.
    /// </summary>
    public class ImplementationLog : Log
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; set; }

        /// <summary>
        /// Wdrożenie.
        /// </summary>
        public Implementation Implementation { get; set; }
    }
}
