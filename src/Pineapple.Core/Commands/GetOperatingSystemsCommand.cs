using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetOperatingSystemsCommand : IRequest<Task<OperatingSystemDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba systemów operacyjnych, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetOperatingSystemsCommand(int? count)
        {
            Count = count;
        }
    }
}
