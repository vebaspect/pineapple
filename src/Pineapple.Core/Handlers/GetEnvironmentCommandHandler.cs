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
    public class GetEnvironmentCommandHandler : RequestHandler<GetEnvironmentCommand, Task<EnvironmentDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetEnvironmentCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<EnvironmentDto> Handle(GetEnvironmentCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var implementation = await databaseContext
                .Implementations
                .Include(implementation => implementation.Environments)
                .ThenInclude(environment => environment.Operator)
                .FirstOrDefaultAsync(implementation => implementation.Id == request.ImplementationId)
                .ConfigureAwait(false);

            if (implementation is null)
            {
                throw new Exception($"Implementation {request.ImplementationId} not exist");
            }

            var environment = implementation
                .Environments?
                .FirstOrDefault(environment => environment.Id == request.EnvironmentId);

            if (environment is null)
            {
                throw new Exception($"Environment {request.EnvironmentId} not exist");
            }

            return Map(environment);
        }

        private static EnvironmentDto Map(Domain.Entities.Environment environment)
        {
            return new EnvironmentDto(
                environment.Id,
                environment.ModifiedDate,
                environment.Name,
                environment.Symbol,
                environment.Description,
                environment.OperatorId,
                environment.Operator.FullName
            );
        }
    }
}
