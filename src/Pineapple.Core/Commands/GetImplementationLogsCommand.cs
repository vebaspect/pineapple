using System;
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetImplementationLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Liczba logów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetImplementationLogsCommand(Guid implementationId, int? count)
        {
            ImplementationId = implementationId;
            Count = count;
        }
    }
}
