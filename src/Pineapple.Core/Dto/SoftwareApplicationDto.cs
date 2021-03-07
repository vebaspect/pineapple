using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Oprogramowanie.
    /// </summary>
    public class SoftwareApplicationDto : IDto
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
        /// Flaga określająca, czy oprogramowanie zostało usunięte.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public SoftwareApplicationDto(Guid id, DateTime modifiedDate, bool isDeleted, string name, string symbol, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            IsDeleted = isDeleted;
            Name = name;
            Symbol = symbol;
            Description = description;
        }
    }
}
