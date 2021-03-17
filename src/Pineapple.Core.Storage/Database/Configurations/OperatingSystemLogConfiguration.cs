using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class OperatingSystemLogConfiguration : IEntityTypeConfiguration<OperatingSystemLog>
    {
        public void Configure(EntityTypeBuilder<OperatingSystemLog> builder)
        {
        }
    }
}
