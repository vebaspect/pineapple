using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Handler
{
    public class GetCoordinatorsCommandHandler : RequestHandler<GetCoordinatorsCommand, Task<CoordinatorDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetCoordinatorsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<CoordinatorDto[]> Handle(GetCoordinatorsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Coordinators)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new Exception($"Implementation {request.ImplementationId} not exist");
            }

            if (implementation.Coordinators?.Count > 0)
            {
                return implementation.Coordinators.Select(coordinator => Map(coordinator)).ToArray();
            }

            return Enumerable.Empty<CoordinatorDto>().ToArray();
        }

        private static CoordinatorDto Map(Domain.Entities.Coordinator coordinator)
        {
            return new CoordinatorDto(coordinator.Id, coordinator.FullName, coordinator.Phone, coordinator.Email);
        }
    }
}
