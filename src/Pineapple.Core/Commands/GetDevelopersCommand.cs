using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetDevelopersCommand : IRequest<Task<UserDto[]>>, ICommand
    {
    }
}
