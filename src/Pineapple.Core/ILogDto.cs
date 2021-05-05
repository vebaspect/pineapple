using System;
using System.Collections.Generic;
using Pineapple.Core.Dto;

namespace Pineapple.Core
{
    public interface ILogDto : IDto
    {
        Guid Id { get; }

        DateTime CreationDate { get; }

        DateTime ModificationDate { get; }

        bool IsDeleted { get; }

        string Type { get; }

        string Category { get; }

        Guid OwnerId { get; }

        string OwnerFullName { get; }

        EntityDto Entity { get; }

        List<EntityDto> ParentEntities { get; }

        string Description { get; }
    }
}
