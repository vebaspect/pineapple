using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class UpdateServerComponentCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator komponentu zainstalowanego na serwerze.
        /// </summary>
        public Guid ServerComponentId { get; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        public UpdateServerComponentCommand(Guid serverComponentId, Guid componentVersionId)
        {
            ServerComponentId = serverComponentId;
            ComponentVersionId = componentVersionId;
        }
    }
}
