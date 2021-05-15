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
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; }

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

        /// <summary>
        /// Identyfikator menedżera.
        /// </summary>
        public Guid? ManagerId { get; }

        /// <summary>
        /// Imię i nazwisko menedżera.
        /// </summary>
        public string ManagerFullName { get; }

        public ImplementationDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string name, string description, Guid? managerId, string managerFullName)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Name = name;
            Description = description;
            ManagerId = managerId;
            ManagerFullName = managerFullName;
        }
    }
}
