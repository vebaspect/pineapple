using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
    {
        public void Configure(EntityTypeBuilder<ComponentType> builder)
        {
            builder.ToTable("ComponentTypes");

            builder
                .Property(componentType => componentType.ModifiedDate)
                .IsRequired();
            builder
                .Property(componentType => componentType.IsDeleted)
                .IsRequired();
            builder
                .Property(componentType => componentType.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(componentType => componentType.Symbol)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(componentType => componentType.Description)
                .HasMaxLength(4000);
        }
    }
}
