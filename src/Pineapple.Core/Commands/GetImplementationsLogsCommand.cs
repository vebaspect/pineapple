using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetImplementationsLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
    }
}
