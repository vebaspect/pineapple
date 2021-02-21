using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class EnvironmentConfiguration : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable("Environments");

            builder
                .Property(environment => environment.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder
                .Property(environment => environment.Symbol)
                .IsRequired()
                .HasMaxLength(255);
            builder
                .Property(environment => environment.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(environment => environment.Implementation)
                .WithMany(implementation => implementation.Environments)
                .HasForeignKey(environment => environment.ImplementationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
