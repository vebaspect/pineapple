using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetImplementationsCommand : IRequest<Task<ImplementationDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba wdrożeń, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetImplementationsCommand(int? count)
        {
            Count = count;
        }
    }
}
