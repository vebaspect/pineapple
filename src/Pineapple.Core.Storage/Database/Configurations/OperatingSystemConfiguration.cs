﻿using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class OperatingSystemConfiguration : IEntityTypeConfiguration<OperatingSystem>
    {
        public void Configure(EntityTypeBuilder<OperatingSystem> builder)
        {
            builder.ToTable("OperatingSystems");

            builder
                .Property(operatingSystem => operatingSystem.ModifiedDate)
                .IsRequired();
            builder
                .Property(operatingSystem => operatingSystem.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(operatingSystem => operatingSystem.Symbol)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(operatingSystem => operatingSystem.Description)
                .HasMaxLength(4000);
        }
    }
}