﻿using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("Servers");

            builder
                .Property(server => server.ModifiedDate)
                .IsRequired();
            builder
                .Property(server => server.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(server => server.Symbol)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(server => server.Description)
                .HasMaxLength(4000);
            builder
                .HasOne(server => server.Environment)
                .WithMany(environment => environment.Servers)
                .HasForeignKey(server => server.EnvironmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(server => server.OperatingSystem)
                .WithMany(operatingSystem => operatingSystem.Servers)
                .HasForeignKey(server => server.OperatingSystemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}