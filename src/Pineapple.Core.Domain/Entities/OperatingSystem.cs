using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// System operacyjny.
    /// </summary>
    public sealed class OperatingSystem : Entity
    {
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
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; }

        /// <summary>
        /// Logi dotyczące systemu operacyjnego.
        /// </summary>
        public List<OperatingSystemLog> EntityLogs { get; }

        private OperatingSystem(Guid id, string name, string symbol, string description)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Symbol = symbol;
            Description = description;
        }

        /// <summary>
        /// Stwórz system operacyjny.
        /// </summary>
        public static OperatingSystem Create(Guid id, string name, string symbol, string description)
        {
            return new OperatingSystem(id, name, symbol, description);
        }
    }
}
