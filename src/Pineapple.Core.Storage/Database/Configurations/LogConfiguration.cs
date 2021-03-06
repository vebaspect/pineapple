﻿using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs", "pineapple");

            builder.HasDiscriminator(log => log.Type);

            builder
                .Property(log => log.ModificationDate)
                .IsRequired();
            builder
                .Property(log => log.IsDeleted)
                .IsRequired();
            builder
                .Property(log => log.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(log => log.Category)
                .HasMaxLength(50);
            builder
                .HasOne(log => log.Owner)
                .WithMany(user => user.OwnedLogs)
                .HasForeignKey(log => log.OwnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
