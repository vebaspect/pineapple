using System;
using System.Collections.Generic;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Log dotyczący serwera.
    /// </summary>
    public class ServerLogDto : LogDto
    {
        /// <summary>
        /// Identyfikator zainstalowanego.
        /// </summary>
        public Guid InstalledEntityId { get; }

        /// <summary>
        /// Typ.
        /// </summary>
        public string InstalledEntityName { get; }

        public ServerLogDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string type, string category, Guid ownerId, string ownerFullName, EntityDto entity, List<EntityDto> parentEntities, string description)
            : base(id, creationDate, modificationDate, isDeleted, type, category, ownerId, ownerFullName, entity, parentEntities, description)
        {
            // TODO
        }
    }
}
