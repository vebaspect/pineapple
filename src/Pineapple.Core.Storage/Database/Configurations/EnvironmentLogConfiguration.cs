using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class EnvironmentLogConfiguration : IEntityTypeConfiguration<EnvironmentLog>
    {
        public void Configure(EntityTypeBuilder<EnvironmentLog> builder)
        {
        }
    }
}
