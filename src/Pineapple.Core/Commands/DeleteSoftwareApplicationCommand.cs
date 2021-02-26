using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteSoftwareApplicationCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        public DeleteSoftwareApplicationCommand(Guid softwareApplicationId)
        {
            SoftwareApplicationId = softwareApplicationId;
        }
    }
}
