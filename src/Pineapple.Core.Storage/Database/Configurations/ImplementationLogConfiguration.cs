using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ImplementationLogConfiguration : IEntityTypeConfiguration<ImplementationLog>
    {
        public void Configure(EntityTypeBuilder<ImplementationLog> builder)
        {
            builder
                .HasOne(implementationLog => implementationLog.Implementation)
                .WithMany(implementation => implementation.EntityLogs)
                .HasForeignKey(implementationLog => implementationLog.ImplementationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
