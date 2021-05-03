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
    public class GetOperatorsCommandHandler : RequestHandler<GetOperatorsCommand, Task<UserDto[]>>, ICommandHandler
    {
        private readonly DatabaseContextFactory databaseContextFactory;

        public GetOperatorsCommandHandler(DatabaseContextFactory databaseContextFactory)
        {
            if (databaseContextFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseContextFactory));
            }

            this.databaseContextFactory = databaseContextFactory;
        }

        protected override async Task<UserDto[]> Handle(GetOperatorsCommand request)
        {
            using var databaseContext = databaseContextFactory.CreateDbContext();

            Domain.Entities.Operator[] operators = null;

            if (request.Count.HasValue)
            {
                operators = await databaseContext
                    .Users
                    .OfType<Domain.Entities.Operator>()
                    .Take(request.Count.Value)
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }
            else
            {
                operators = await databaseContext
                    .Users
                    .OfType<Domain.Entities.Operator>()
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (operators?.Length > 0)
            {
                return operators
                    .OrderBy(@operator => @operator.FullName)
                    .Select(@operator =>@operator.ToDto()).ToArray();
            }

            return Enumerable.Empty<UserDto>().ToArray();
        }
    }
}
