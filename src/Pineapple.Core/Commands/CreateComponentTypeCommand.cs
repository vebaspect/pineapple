using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateComponentTypeCommand : IRequest<Task<Guid>>, ICommand
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

        public CreateComponentTypeCommand(string name, string symbol, string description)
        {
            Name = name;
            Symbol = symbol;
            Description = description;
        }
    }
}
