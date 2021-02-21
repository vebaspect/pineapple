
using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Domain.Entities;
using Pineapple.Core.Dto;
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

            var implementations = await databaseContext
                .Implementations
                .ToArrayAsync()
                .ConfigureAwait(false);

            if (implementations?.Length > 0)
            {
                return implementations.Select(implementation => Map(implementation)).ToArray();
            }

            return Enumerable.Empty<ImplementationDto>().ToArray();
        }

        private static ImplementationDto Map(Domain.Entities.Implementation implementation)
        {
            return new ImplementationDto(implementation.Id, implementation.Name, implementation.Description);
        }
    }
}
