using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Produkt.
    /// </summary>
    public class ProductDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModifiedDate { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public ProductDto(Guid id, DateTime modifiedDate, string name, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Name = name;
            Description = description;
        }
    }
}
