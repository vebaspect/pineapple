using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetDevelopersCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
