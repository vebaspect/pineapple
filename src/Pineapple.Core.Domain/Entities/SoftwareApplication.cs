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
        public string Name { get; set; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; set; }

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
