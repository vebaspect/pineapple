using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentTypeLogConfiguration : IEntityTypeConfiguration<ComponentTypeLog>
    {
        public void Configure(EntityTypeBuilder<ComponentTypeLog> builder)
        {
        }
    }
}
