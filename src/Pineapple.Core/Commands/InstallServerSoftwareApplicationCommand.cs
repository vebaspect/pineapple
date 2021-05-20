using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class InstallServerSoftwareApplicationCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        public InstallServerSoftwareApplicationCommand(Guid serverId, Guid softwareApplicationId)
        {
            ServerId = serverId;
            SoftwareApplicationId = softwareApplicationId;
        }
    }
}
