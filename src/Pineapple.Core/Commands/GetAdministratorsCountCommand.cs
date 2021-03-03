using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetAdministratorsCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
