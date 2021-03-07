using System;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

namespace Pineapple.Core.Handler
{
    public class GetCoordinatorCommandHandler : RequestHandler<GetCoordinatorCommand, Task<CoordinatorDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetCoordinatorCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<CoordinatorDto> Handle(GetCoordinatorCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Coordinators)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new ImplementationNotFoundException($"Implementation {request.ImplementationId} has not been found");
            }

            var coordinator = implementation
                .Coordinators?
                .FirstOrDefault(coordinator => coordinator.Id == request.CoordinatorId);

            if (coordinator is null)
            {
                throw new CoordinatorNotFoundException($"Coordinator {request.CoordinatorId} has not been found");
            }

            return Map(coordinator);
        }

        private static CoordinatorDto Map(Domain.Entities.Coordinator coordinator)
        {
            return new CoordinatorDto(
                coordinator.Id,
                coordinator.ModifiedDate,
                coordinator.IsDeleted,
                coordinator.FullName,
                coordinator.Phone,
                coordinator.Email
            );
        }
    }
}
