using System;
using System.Collections.Generic;

namespace Pineapple.Core.Dto.Logs
{
    public interface ILogDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Data utworzenia.
        /// </summary>
        DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        DateTime ModificationDate { get; }

        /// <summary>
        /// Flaga określająca, czy log został usunięty.
        /// </summary>
        bool IsDeleted { get; }

        /// <summary>
        /// Typ.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Kategoria.
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Identyfikator właściciela.
        /// </summary>
        Guid OwnerId { get; }

        /// <summary>
        /// Imię i nazwisko właściciela.
        /// </summary>
        string OwnerFullName { get; }

        /// <summary>
        /// Encja.
        /// </summary>
        ExtendedEntityDto Entity { get; }

        /// <summary>
        /// Encje nadrzędne.
        /// </summary>
        List<EntityDto> ParentEntities { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        string Description { get; }
    }
}
