using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Oprogramowanie.
    /// </summary>
    public sealed class SoftwareApplication : Entity
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

        private SoftwareApplication(Guid id, string name, string symbol, string description)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Symbol = symbol;
            Description = description;
        }

        /// <summary>
        /// Stwórz oprogramowanie.
        /// </summary>
        public static SoftwareApplication Create(Guid id, string name, string symbol, string description)
        {
            return new SoftwareApplication(id, name, symbol, description);
        }
    }
}
