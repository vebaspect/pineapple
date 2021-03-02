using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatorsCommand : IRequest<Task<UserDto[]>>, ICommand
    {
    }
}
