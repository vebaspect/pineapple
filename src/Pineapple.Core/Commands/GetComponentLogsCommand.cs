using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto.Logs;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentLogsCommand : IRequest<Task<ILogDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        /// <summary>
        /// Liczba logów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetComponentLogsCommand(Guid componentId, int? count)
        {
            ComponentId = componentId;
            Count = count;
        }
    }
}
