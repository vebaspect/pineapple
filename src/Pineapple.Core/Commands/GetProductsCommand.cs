using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class GetProductsCommand : IRequest<Task<ProductDto[]>>, ICommand
    {
        /// <summary>
        /// Liczba produktów, które mają zostać zwrócone.
        /// </summary>
        public int? Count { get; }

        public GetProductsCommand(int? count)
        {
            Count = count;
        }
    }
}
