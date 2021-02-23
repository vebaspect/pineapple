using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateComponentCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        public CreateComponentCommand(Guid productId, string name, string description, Guid componentTypeId)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            ComponentTypeId = componentTypeId;
        }
    }
}
