using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatorsCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
