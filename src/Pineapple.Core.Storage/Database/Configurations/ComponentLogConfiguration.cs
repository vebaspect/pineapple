using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentLogConfiguration : IEntityTypeConfiguration<ComponentLog>
    {
        public void Configure(EntityTypeBuilder<ComponentLog> builder)
        {
        }
    }
}
