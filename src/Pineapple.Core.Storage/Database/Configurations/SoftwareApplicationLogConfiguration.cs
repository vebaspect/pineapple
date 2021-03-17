using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class SoftwareApplicationLogConfiguration : IEntityTypeConfiguration<SoftwareApplicationLog>
    {
        public void Configure(EntityTypeBuilder<SoftwareApplicationLog> builder)
        {
        }
    }
}
