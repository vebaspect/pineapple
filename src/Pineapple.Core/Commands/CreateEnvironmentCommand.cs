using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateEnvironmentCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

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

        public CreateEnvironmentCommand(Guid implementationId, string name, string symbol, string description)
        {
            ImplementationId = implementationId;
            Name = name;
            Symbol = symbol;
            Description = description;
        }
    }
}
