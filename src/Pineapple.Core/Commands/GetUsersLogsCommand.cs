using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetUsersLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba logów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetUsersLogsCommand(int? count)
        {
            Count = count;
        }
    }
}
