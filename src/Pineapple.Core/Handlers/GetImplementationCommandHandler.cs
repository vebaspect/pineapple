using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Exceptions;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetImplementationCommandHandler : RequestHandler<GetImplementationCommand, Task<ImplementationDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetImplementationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ImplementationDto> Handle(GetImplementationCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new ImplementationNotFoundException($"Implementation {request.ImplementationId} has not been found");
            }

            return implementation.ToDto();
        }
    }
}
