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
    public class GetSoftwareApplicationCommandHandler : RequestHandler<GetSoftwareApplicationCommand, Task<SoftwareApplicationDto>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetSoftwareApplicationCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<SoftwareApplicationDto> Handle(GetSoftwareApplicationCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            var softwareApplication = await databaseContext
                .SoftwareApplications
                .FirstOrDefaultAsync(softwareApplication => softwareApplication.Id == request.SoftwareApplicationId)
                .ConfigureAwait(false);

            if (softwareApplication is null)
            {
                throw new SoftwareApplicationNotFoundException($"SoftwareApplication {request.SoftwareApplicationId} has not been found");
            }

            return softwareApplication.ToDto();
        }
    }
}
