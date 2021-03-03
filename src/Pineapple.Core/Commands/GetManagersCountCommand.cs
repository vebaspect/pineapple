using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetManagersCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
