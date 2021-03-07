using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Wdrożenie.
    /// </summary>
    public class ImplementationDto : IDto
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
        /// Flaga określająca, czy wdrożenie zostało usunięte.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public ImplementationDto(Guid id, DateTime modifiedDate, bool isDeleted, string name, string description)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            IsDeleted = isDeleted;
            Name = name;
            Description = description;
        }
    }
}
