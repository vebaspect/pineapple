using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentTypesCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
