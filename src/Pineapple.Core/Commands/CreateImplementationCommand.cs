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

        /// <summary>
        /// Identyfikator menedżera.
        /// </summary>
        public Guid? ManagerId { get; }

        public CreateImplementationCommand(string name, string description, Guid? managerId)
        {
            Name = name;
            Description = description;
            ManagerId = managerId;
        }
    }
}
