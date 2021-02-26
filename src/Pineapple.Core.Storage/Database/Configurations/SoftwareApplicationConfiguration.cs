using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class SoftwareApplicationConfiguration : IEntityTypeConfiguration<SoftwareApplication>
    {
        public void Configure(EntityTypeBuilder<SoftwareApplication> builder)
        {
            builder.ToTable("SoftwareApplications");

            builder
                .Property(software => software.ModifiedDate)
                .IsRequired();
            builder
                .Property(software => software.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(software => software.Symbol)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(software => software.Description)
                .HasMaxLength(4000);
        }
    }
}
