using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Log dotyczący produktu.
    /// </summary>
    public sealed class ProductLog : Log
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Produkt.
        /// </summary>
        public Product Product { get; }

        private ProductLog(Guid id, string category, Guid ownerId, Guid productId)
            : base(id)
        {
            Category = category;
            OwnerId = ownerId;
            ProductId = productId;
        }

        /// <summary>
        /// Stwórz log.
        /// </summary>
        public static ProductLog Create(Guid id, string category, Guid ownerId, Guid productId)
        {
            return new ProductLog(id, category, ownerId, productId);
        }
    }
}
