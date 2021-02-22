using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class VersionConfiguration : IEntityTypeConfiguration<Version>
    {
        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable("Versions");

            builder
                .Property(version => version.ModifiedDate)
                .IsRequired();
            builder
                .Property(version => version.Major)
                .IsRequired();
            builder
                .Property(version => version.Minor)
                .IsRequired();
            builder
                .Property(version => version.Patch)
                .IsRequired();
            builder
                .Property(version => version.PreRelease)
                .HasMaxLength(30);
            builder
                .Property(version => version.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(version => version.Component)
                .WithMany(component => component.Versions)
                .HasForeignKey(version => version.ComponentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
