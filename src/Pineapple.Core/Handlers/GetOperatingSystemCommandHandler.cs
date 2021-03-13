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
    public class GetOperatingSystemCommandHandler : RequestHandler<GetOperatingSystemCommand, Task<OperatingSystemDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetOperatingSystemCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<OperatingSystemDto> Handle(GetOperatingSystemCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var operatingSystem = await databaseContext
                .OperatingSystems
                .FirstOrDefaultAsync(operatingSystem => operatingSystem.Id == request.OperatingSystemId)
                .ConfigureAwait(false);

            if (operatingSystem is null)
            {
                throw new OperatingSystemNotFoundException($"OperatingSystem {request.OperatingSystemId} has not been found");
            }

            return operatingSystem.ToDto();
        }
    }
}
