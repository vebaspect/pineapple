using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ServerLogConfiguration : IEntityTypeConfiguration<ServerLog>
    {
        public void Configure(EntityTypeBuilder<ServerLog> builder)
        {
        }
    }
}
