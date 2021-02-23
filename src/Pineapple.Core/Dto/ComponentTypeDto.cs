using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Typ komponentu.
    /// </summary>
    public class ComponentTypeDto : IDto
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
        /// Symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public ComponentTypeDto(Guid id, DateTime modifiedDate, string name, string symbol, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Name = name;
            Symbol = symbol;
            Description = description;
        }
    }
}
