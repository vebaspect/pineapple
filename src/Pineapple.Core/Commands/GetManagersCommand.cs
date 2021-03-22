using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetManagersCommand : IRequest<Task<UserDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba menedżerów, którzy mają zostać zwróceni.
        /// </summary>
        public int? Count { get; }

        public GetManagersCommand(int? count)
        {
            Count = count;
        }
    }
}
