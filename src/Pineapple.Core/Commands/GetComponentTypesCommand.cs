using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentTypesCommand : IRequest<Task<ComponentTypeDto[]>>, ICommand
    {
        public GetComponentTypesCommand()
        {
        }
    }
}
