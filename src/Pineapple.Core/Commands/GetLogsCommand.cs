using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
    }
}
