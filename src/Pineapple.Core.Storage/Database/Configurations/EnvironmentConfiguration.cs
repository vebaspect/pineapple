using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class EnvironmentConfiguration : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable("Environments", "pineapple");

            builder
                .Property(environment => environment.ModificationDate)
                .IsRequired();
            builder
                .Property(environment => environment.IsDeleted)
                .IsRequired();
            builder
                .Property(environment => environment.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(environment => environment.Symbol)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(environment => environment.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(environment => environment.Implementation)
                .WithMany(implementation => implementation.Environments)
                .HasForeignKey(environment => environment.ImplementationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(environment => environment.Operator)
                .WithMany(@operator => @operator.Environments)
                .HasForeignKey(environment => environment.OperatorId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(environment => environment.EntityLogs)
                .WithOne(log => log.Environment)
                .HasForeignKey(log => log.EnvironmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
