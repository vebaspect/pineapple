using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetAdministratorsCommand : IRequest<Task<UserDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba administratorów, którzy mają zostać zwróceni.
        /// </summary>
        public int? Count { get; }

        public GetAdministratorsCommand(int? count)
        {
            Count = count;
        }
    }
}
