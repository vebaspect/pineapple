using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class InstallComponentCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        public InstallComponentCommand(Guid serverId, Guid componentVersionId)
        {
            ServerId = serverId;
            ComponentVersionId = componentVersionId;
        }
    }
}
