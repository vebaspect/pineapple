using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatorsCommand : IRequest<Task<UserDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba wdrożeniowców, którzy mają zostać zwróceni.
        /// </summary>
        public int? Count { get; }

        public GetOperatorsCommand(int? count)
        {
            Count = count;
        }
    }
}
