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
        public Guid ProductId { get; set; }

        /// <summary>
        /// Produkt.
        /// </summary>
        public Product Product { get; set; }

        private ProductLog(Guid id, string category, Guid ownerId, Guid productId)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
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
