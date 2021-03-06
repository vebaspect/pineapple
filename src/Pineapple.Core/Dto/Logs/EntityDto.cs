using System;

namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Informacje nt. encji.
    /// </summary>
    public class EntityDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        public EntityDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
