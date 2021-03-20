using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentsLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba logów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetComponentsLogsCommand(int? count)
        {
            Count = count;
        }
    }
}
