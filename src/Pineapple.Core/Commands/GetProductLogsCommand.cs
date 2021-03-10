using System.Threading.Tasks;
using Pineapple.Core.Dto;
using MediatR;
using System;

namespace Pineapple.Core.Commands
{
    public class GetProductLogsCommand : IRequest<Task<LogDto[]>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        public GetProductLogsCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
