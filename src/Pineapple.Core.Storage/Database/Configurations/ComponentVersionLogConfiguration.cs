using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentVersionLogConfiguration : IEntityTypeConfiguration<ComponentVersionLog>
    {
        public void Configure(EntityTypeBuilder<ComponentVersionLog> builder)
        {
        }
    }
}
