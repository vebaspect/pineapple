using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ComponentVersionConfiguration : IEntityTypeConfiguration<ComponentVersion>
    {
        public void Configure(EntityTypeBuilder<ComponentVersion> builder)
        {
            builder.ToTable("ComponentVersions");

            builder
                .Property(componentVersion => componentVersion.ModifiedDate)
                .IsRequired();
            builder
                .Property(componentVersion => componentVersion.IsDeleted)
                .IsRequired();
            builder
                .Property(componentVersion => componentVersion.Major)
                .IsRequired();
            builder
                .Property(componentVersion => componentVersion.Minor)
                .IsRequired();
            builder
                .Property(componentVersion => componentVersion.Patch)
                .IsRequired();
            builder
                .Property(componentVersion => componentVersion.PreRelease)
                .HasMaxLength(30);
            builder
                .Property(componentVersion => componentVersion.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(componentVersion => componentVersion.Component)
                .WithMany(component => component.ComponentVersions)
                .HasForeignKey(componentVersion => componentVersion.ComponentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(componentVersion => componentVersion.EntityLogs)
                .WithOne(log => log.ComponentVersion)
                .HasForeignKey(log => log.ComponentVersionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
