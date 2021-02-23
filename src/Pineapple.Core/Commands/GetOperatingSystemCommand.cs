using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatingSystemCommand : IRequest<Task<OperatingSystemDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; }

        public GetOperatingSystemCommand(Guid operatingSystemId)
        {
            OperatingSystemId = operatingSystemId;
        }
    }
}
