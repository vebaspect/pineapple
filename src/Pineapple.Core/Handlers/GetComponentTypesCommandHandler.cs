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
    public class GetComponentTypesCommandHandler : RequestHandler<GetComponentTypesCommand, Task<ComponentTypeDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetComponentTypesCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<ComponentTypeDto[]> Handle(GetComponentTypesCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            Domain.Entities.ComponentType[] componentTypes = null;

            if (request.Count.HasValue)
            {
                componentTypes = await databaseContext
                    .ComponentTypes
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                componentTypes = await databaseContext
                    .ComponentTypes
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (componentTypes?.Length > 0)
            {
                return componentTypes.Select(componentType => componentType.ToDto()).ToArray();
            }

            return Enumerable.Empty<ComponentTypeDto>().ToArray();
        }
    }
}
