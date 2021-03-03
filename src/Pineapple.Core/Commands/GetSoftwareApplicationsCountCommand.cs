using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetSoftwareApplicationsCountCommand : IRequest<Task<int>>, ICommand
    {
    }
}
