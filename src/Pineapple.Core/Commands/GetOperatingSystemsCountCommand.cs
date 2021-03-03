using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatingSystemsCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
