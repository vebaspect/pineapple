using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
    {
        public void Configure(EntityTypeBuilder<ComponentType> builder)
        {
            builder.ToTable("ComponentTypes", "pineapple");

            builder
                .Property(componentType => componentType.ModificationDate)
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
            builder
                .HasMany(componentType => componentType.EntityLogs)
                .WithOne(log => log.ComponentType)
                .HasForeignKey(log => log.ComponentTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
