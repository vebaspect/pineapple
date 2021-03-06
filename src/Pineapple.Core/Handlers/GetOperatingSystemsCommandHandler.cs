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
    public class GetOperatingSystemsCommandHandler : RequestHandler<GetOperatingSystemsCommand, Task<OperatingSystemDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetOperatingSystemsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<OperatingSystemDto[]> Handle(GetOperatingSystemsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            Domain.Entities.OperatingSystem[] operatingSystems = null;

            if (request.Count.HasValue)
            {
                operatingSystems = await databaseContext
                    .OperatingSystems
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                operatingSystems = await databaseContext
                    .OperatingSystems
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (operatingSystems?.Length > 0)
            {
                return operatingSystems
                    .OrderBy(operatingSystem => operatingSystem.Name)
                    .Select(operatingSystem => operatingSystem.ToDto()).ToArray();
            }

            return Enumerable.Empty<OperatingSystemDto>().ToArray();
        }
    }
}
