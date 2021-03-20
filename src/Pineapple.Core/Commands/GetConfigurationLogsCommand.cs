using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetConfigurationLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba logów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetConfigurationLogsCommand(int? count)
        {
            Count = count;
        }
    }
}
