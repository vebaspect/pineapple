using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący produktu.
    /// </summary>
    public class ProductLog : Log
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Produkt.
        /// </summary>
        public Product Product { get; set; }
    }
}
