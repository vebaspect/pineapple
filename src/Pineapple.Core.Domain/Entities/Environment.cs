using System;
using System.Collections.Generic;
using Pineapple.Core.Domain.Exceptions;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Środowisko.
    /// </summary>
    public sealed class Environment : Entity
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
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Wdrożenie.
        /// </summary>
        public Implementation Implementation { get; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public List<Server> Servers { get; }

        /// <summary>
        /// Identyfikator wdrożeniowca.
        /// </summary>
        public Guid OperatorId { get; }

        /// <summary>
        /// Wdrożeniowiec.
        /// </summary>
        public Operator Operator { get; }

        /// <summary>
        /// Logi dotyczące środowiska.
        /// </summary>
        public List<EnvironmentLog> EntityLogs { get; }

        private Environment(Guid id, string name, string symbol, string description, Guid implementationId, Guid operatorId)
        {
            Id = id;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Symbol = symbol;
            Description = description;
            ImplementationId = implementationId;
            OperatorId = operatorId;
        }

        /// <summary>
        /// Stwórz środowisko.
        /// </summary>
        public static Environment Create(Guid id, string name, string symbol, string description, Guid implementationId, Guid operatorId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValueRequiredValidationException(nameof(name));
            }
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ValueRequiredValidationException(nameof(symbol));
            }
            if (implementationId == Guid.Empty)
            {
                throw new ValueRequiredValidationException(nameof(implementationId));
            }
            if (operatorId == Guid.Empty)
            {
                throw new ValueRequiredValidationException(nameof(operatorId));
            }

            return new Environment(id, name, symbol, description, implementationId, operatorId);
        }
    }
}
