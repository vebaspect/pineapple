using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class UninstallServerSoftwareApplicationCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator oprogramowania zainstalowanego na serwerze.
        /// </summary>
        public Guid ServerSoftwareApplicationId { get; }

        public UninstallServerSoftwareApplicationCommand(Guid serverSoftwareApplicationId)
        {
            ServerSoftwareApplicationId = serverSoftwareApplicationId;
        }
    }
}
