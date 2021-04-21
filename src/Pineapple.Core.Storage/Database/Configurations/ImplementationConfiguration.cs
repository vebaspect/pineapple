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
                .Property(implementation => implementation.ModificationDate)
                .IsRequired();
            builder
                .Property(implementation => implementation.IsDeleted)
                .IsRequired();
            builder
                .Property(implementation => implementation.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(implementation => implementation.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(implementation => implementation.Manager)
                .WithMany(manager => manager.Implementations)
                .HasForeignKey(implementation => implementation.ManagerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(implementation => implementation.EntityLogs)
                .WithOne(log => log.Implementation)
                .HasForeignKey(log => log.ImplementationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
