using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetComponentTypesCommand : IRequest<Task<ComponentTypeDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba typów komponentów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetComponentTypesCommand(int? count)
        {
            Count = count;
        }
    }
}
