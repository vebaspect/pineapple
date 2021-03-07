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
                .Property(softwareApplication => softwareApplication.ModifiedDate)
                .IsRequired();
            builder
                .Property(softwareApplication => softwareApplication.IsDeleted)
                .IsRequired();
            builder
                .Property(softwareApplication => softwareApplication.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(softwareApplication => softwareApplication.Symbol)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(softwareApplication => softwareApplication.Description)
                .HasMaxLength(4000);
        }
    }
}
