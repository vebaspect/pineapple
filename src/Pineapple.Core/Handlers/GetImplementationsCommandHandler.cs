using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Mappers;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetImplementationsCommandHandler : RequestHandler<GetImplementationsCommand, Task<ImplementationDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetImplementationsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ImplementationDto[]> Handle(GetImplementationsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            Domain.Entities.Implementation[] implementations = null;

            if (request.Count.HasValue)
            {
                implementations = await databaseContext
                    .Implementations
                    .Include(implementation => implementation.Manager)
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                implementations = await databaseContext
                    .Implementations
                    .Include(implementation => implementation.Manager)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (implementations?.Length > 0)
            {
                return implementations.Select(implementation => implementation.ToDto()).ToArray();
            }

            return Enumerable.Empty<ImplementationDto>().ToArray();
        }
    }
}
