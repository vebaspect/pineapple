using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetSoftwareApplicationsCommand : IRequest<Task<SoftwareApplicationDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba oprogramowania, które ma zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetSoftwareApplicationsCommand(int? count)
        {
            Count = count;
        }
    }
}
