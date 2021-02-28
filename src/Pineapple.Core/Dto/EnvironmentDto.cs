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

        /// <summary>
        /// Identyfikator wdrożeniowca.
        /// </summary>
        public Guid OperatorId { get; }

        /// <summary>
        /// Imię i nazwisko wdrożeniowca.
        /// </summary>
        public string OperatorFullName { get; }

        public EnvironmentDto(Guid id, DateTime modifiedDate, string name, string symbol, string description, Guid operatorId, string operatorFullName)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Name = name;
            Symbol = symbol;
            Description = description;
            OperatorId = operatorId;
            OperatorFullName = operatorFullName;
        }
    }
}
