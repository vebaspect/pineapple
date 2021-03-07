using System;
using System.Threading.Tasks;
using Pineapple.Core.Commands;
using Pineapple.Core.Dto;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pineapple.Core.Exceptions;

namespace Pineapple.Core.Handler
{
    public class GetComponentTypeCommandHandler : RequestHandler<GetComponentTypeCommand, Task<ComponentTypeDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentTypeCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ComponentTypeDto> Handle(GetComponentTypeCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var componentType = await databaseContext
                .ComponentTypes
                .FirstOrDefaultAsync(componentType => componentType.Id == request.ComponentTypeId)
                .ConfigureAwait(false);

            if (componentType is null)
            {
                throw new ComponentTypeNotFoundException($"ComponentType {request.ComponentTypeId} has not been found");
            }

            return Map(componentType);
        }

        private static ComponentTypeDto Map(Domain.Entities.ComponentType componentType)
        {
            return new ComponentTypeDto(
                componentType.Id,
                componentType.ModifiedDate,
                componentType.IsDeleted,
                componentType.Name,
                componentType.Symbol,
                componentType.Description
            );
        }
    }
}
