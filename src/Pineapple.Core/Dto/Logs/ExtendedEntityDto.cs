using System;

namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Rozszerzone informacje nt. encji.
    /// </summary>
    public class ExtendedEntityDto : EntityDto
    {
        /// <summary>
        /// Szczegółowe informacje nt. encji.
        /// </summary>
        public EntityDetailsDto Details { get; }

        public ExtendedEntityDto(Guid id, string name, EntityDetailsDto details)
            : base(id, name)
        {
            Details = details;
        }
    }
}
