using System.Threading.Tasks;
using Pineapple.Core.Dto.Logs;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetLogsCommand : IRequest<Task<ILogDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba logów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetLogsCommand(int? count)
        {
            Count = count;
        }
    }
}
