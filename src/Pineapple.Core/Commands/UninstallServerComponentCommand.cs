using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class UninstallServerComponentCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator komponentu zainstalowanego na serwerze.
        /// </summary>
        public Guid ServerComponentId { get; }

        public UninstallServerComponentCommand(Guid serverComponentId)
        {
            ServerComponentId = serverComponentId;
        }
    }
}
