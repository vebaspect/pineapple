using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class CoordinatorConfiguration : IEntityTypeConfiguration<Coordinator>
    {
        public void Configure(EntityTypeBuilder<Coordinator> builder)
        {
            builder.ToTable("Coordinators");

            builder
                .Property(coordinator => coordinator.ModificationDate)
                .IsRequired();
            builder
                .Property(coordinator => coordinator.IsDeleted)
                .IsRequired();
            builder
                .Property(coordinator => coordinator.FullName)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(coordinator => coordinator.Phone)
                .HasMaxLength(20);
            builder
                .Property(coordinator => coordinator.Email)
                .HasMaxLength(100);
            builder
                .HasOne(coordinator => coordinator.Implementation)
                .WithMany(implementation => implementation.Coordinators)
                .HasForeignKey(coordinator => coordinator.ImplementationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
