using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateImplementationCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public CreateImplementationCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
