using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ServerSoftwareApplicationLogConfiguration : IEntityTypeConfiguration<ServerSoftwareApplicationLog>
    {
        public void Configure(EntityTypeBuilder<ServerSoftwareApplicationLog> builder)
        {
        }
    }
}
