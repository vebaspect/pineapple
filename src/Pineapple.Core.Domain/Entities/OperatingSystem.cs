using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

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
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
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
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ValueRequiredValidationException(nameof(symbol));
            }

            return new OperatingSystem(id, name, symbol, description);
        }
    }
}
