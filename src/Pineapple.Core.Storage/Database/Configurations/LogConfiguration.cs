using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            builder.HasDiscriminator(log => log.Type);

            builder
                .Property(log => log.ModifiedDate)
                .IsRequired();
            builder
                .Property(log => log.Type)
                .IsRequired()
                .HasMaxLength(20);
            builder
                .Property(log => log.Category)
                .HasMaxLength(50);
            builder
                .HasOne(log => log.User)
                .WithMany(user => user.Logs)
                .HasForeignKey(log => log.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(log => log.Description)
                .HasMaxLength(4000);
        }
    }
}
