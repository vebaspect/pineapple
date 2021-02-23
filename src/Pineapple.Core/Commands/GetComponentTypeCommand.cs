using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentTypeCommand : IRequest<Task<ComponentTypeDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        public GetComponentTypeCommand(Guid componentTypeId)
        {
            ComponentTypeId = componentTypeId;
        }
    }
}
