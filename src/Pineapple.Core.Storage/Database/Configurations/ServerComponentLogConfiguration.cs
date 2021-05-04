using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ServerComponentLogConfiguration : IEntityTypeConfiguration<ServerComponentLog>
    {
        public void Configure(EntityTypeBuilder<ServerComponentLog> builder)
        {
        }
    }
}
