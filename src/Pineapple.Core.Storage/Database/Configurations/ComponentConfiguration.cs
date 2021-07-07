using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.ToTable("Components", "pineapple");

            builder
                .Property(component => component.ModificationDate)
                .IsRequired();
            builder
                .Property(component => component.IsDeleted)
                .IsRequired();
            builder
                .Property(component => component.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(component => component.SourceCodeRepositoryUrl)
                .HasMaxLength(2000);
            builder
                .Property(component => component.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(component => component.Product)
                .WithMany(product => product.Components)
                .HasForeignKey(component => component.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(component => component.ComponentType)
                .WithMany(componentType => componentType.Components)
                .HasForeignKey(component => component.ComponentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(component => component.EntityLogs)
                .WithOne(log => log.Component)
                .HasForeignKey(log => log.ComponentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
