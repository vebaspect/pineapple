using System.Threading.Tasks;
using Pineapple.Core.Dto.ProductsTree;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetProductsTreeCommand : IRequest<Task<ProductsTreeDto>>, ICommand
    {
    }
}
