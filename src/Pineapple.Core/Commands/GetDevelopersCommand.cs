using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetDevelopersCommand : IRequest<Task<UserDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba programistów, którzy mają zostać zwróceni.
        /// </summary>
        public int? Count { get; }

        public GetDevelopersCommand(int? count)
        {
            Count = count;
        }
    }
}
