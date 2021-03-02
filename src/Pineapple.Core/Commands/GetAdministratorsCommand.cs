using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetAdministratorsCommand : IRequest<Task<UserDto[]>>, ICommand
    {
    }
}
