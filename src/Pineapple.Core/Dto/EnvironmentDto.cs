using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Środowisko.
    /// </summary>
    public class EnvironmentDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

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

        public EnvironmentDto(Guid id, string name, string symbol, string description)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            Description = description;
        }
    }
}
