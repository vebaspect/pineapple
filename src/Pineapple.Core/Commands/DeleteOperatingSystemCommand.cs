using System;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class DeleteOperatingSystemCommand : IRequest, ICommand
    {
        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; }

        public DeleteOperatingSystemCommand(Guid operatingSystemId)
        {
            OperatingSystemId = operatingSystemId;
        }
    }
}
