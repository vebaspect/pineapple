using System;
using System.Collections.Generic;

namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Log.
    /// </summary>
    public class LogDto : ILogDto
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
        /// Flaga określająca, czy log został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Kategoria.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Identyfikator właściciela.
        /// </summary>
        public Guid OwnerId { get; }

        /// <summary>
        /// Imię i nazwisko właściciela.
        /// </summary>
        public string OwnerFullName { get; }

        /// <summary>
        /// Encja.
        /// </summary>
        public ExtendedEntityDto Entity { get; }

        /// <summary>
        /// Encje nadrzędne.
        /// </summary>
        public List<EntityDto> ParentEntities { get; }

        public LogDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string type, string category, Guid ownerId, string ownerFullName, ExtendedEntityDto entity, List<EntityDto> parentEntities)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Type = type;
            Category = category;
            OwnerId = ownerId;
            OwnerFullName = ownerFullName;
            Entity = entity;
            ParentEntities = parentEntities;
        }
    }
}
