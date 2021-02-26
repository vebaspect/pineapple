using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetSoftwareApplicationCommand : IRequest<Task<SoftwareApplicationDto>>, ICommand
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        public GetSoftwareApplicationCommand(Guid softwareApplicationId)
        {
            SoftwareApplicationId = softwareApplicationId;
        }
    }
}
