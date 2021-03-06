using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

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
        /// Serwery na których jest zainstalowane.
        /// </summary>
        public List<ServerSoftwareApplication> Servers { get; }

        /// <summary>
        /// Logi dotyczące oprogramowania.
        /// </summary>
        public List<SoftwareApplicationLog> EntityLogs { get; }

        private SoftwareApplication(Guid id, string name, string symbol, string description)
            : base(id)
        {
            Name = name;
            Symbol = symbol;
            Description = description;
        }

        /// <summary>
        /// Stwórz oprogramowanie.
        /// </summary>
        public static SoftwareApplication Create(Guid id, string name, string symbol, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ValueRequiredValidationException(nameof(symbol));
            }

            return new SoftwareApplication(id, name, symbol, description);
        }
    }
}
