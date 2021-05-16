using System.Threading.Tasks;
using Pineapple.Core.Dto.ImplementationsTree;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetImplementationsTreeCommand : IRequest<Task<ImplementationsTreeDto>>, ICommand
    {
    }
}
