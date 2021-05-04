using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class UninstallSoftwareApplicationCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        public UninstallSoftwareApplicationCommand(Guid serverId, Guid softwareApplicationId)
        {
            ServerId = serverId;
            SoftwareApplicationId = softwareApplicationId;
        }
    }
}
