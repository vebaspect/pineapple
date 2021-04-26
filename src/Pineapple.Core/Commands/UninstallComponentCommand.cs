using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class UninstallComponentCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        public UninstallComponentCommand(Guid serverId, Guid componentVersionId)
        {
            ServerId = serverId;
            ComponentVersionId = componentVersionId;
        }
    }
}
