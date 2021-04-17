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
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; }

        /// <summary>
        /// Flaga określająca, czy środowisko zostało usunięte.
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

        /// <summary>
        /// Identyfikator wdrożeniowca.
        /// </summary>
        public Guid OperatorId { get; }

        /// <summary>
        /// Imię i nazwisko wdrożeniowca.
        /// </summary>
        public string OperatorFullName { get; }

        public EnvironmentDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string name, string symbol, string description, Guid operatorId, string operatorFullName)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Name = name;
            Symbol = symbol;
            Description = description;
            OperatorId = operatorId;
            OperatorFullName = operatorFullName;
        }
    }
}
