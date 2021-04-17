using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasDiscriminator(user => user.Type);

            builder
                .Property(user => user.ModificationDate)
                .IsRequired();
            builder
                .Property(user => user.IsDeleted)
                .IsRequired();
            builder
                .Property(user => user.Type)
                .IsRequired()
                .HasMaxLength(20);
            builder
                .Property(user => user.FullName)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(user => user.Login)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(user => user.Phone)
                .HasMaxLength(20);
            builder
                .Property(user => user.Email)
                .HasMaxLength(100);
            builder
                .HasMany(user => user.OwnedLogs)
                .WithOne(log => log.Owner)
                .HasForeignKey(log => log.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(user => user.EntityLogs)
                .WithOne(log => log.User)
                .HasForeignKey(log => log.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
