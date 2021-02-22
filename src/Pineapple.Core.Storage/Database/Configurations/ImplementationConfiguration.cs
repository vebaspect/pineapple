using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ImplementationConfiguration : IEntityTypeConfiguration<Implementation>
    {
        public void Configure(EntityTypeBuilder<Implementation> builder)
        {
            builder.ToTable("Implementations");

            builder
                .Property(implementation => implementation.ModifiedDate)
                .IsRequired();
            builder
                .Property(implementation => implementation.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(implementation => implementation.Description)
                .HasMaxLength(4000);
        }
    }
}
