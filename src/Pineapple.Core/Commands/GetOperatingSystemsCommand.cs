using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatingSystemsCommand : IRequest<Task<OperatingSystemDto[]>>, ICommand
    {
        public GetOperatingSystemsCommand()
        {
        }
    }
}
