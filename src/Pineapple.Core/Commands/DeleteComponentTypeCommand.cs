using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteComponentTypeCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        public DeleteComponentTypeCommand(Guid componentTypeId)
        {
            ComponentTypeId = componentTypeId;
        }
    }
}
