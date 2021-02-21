
using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetImplementationsCommand : IRequest<Task<ImplementationDto[]>>, ICommand
    {
    }
}
