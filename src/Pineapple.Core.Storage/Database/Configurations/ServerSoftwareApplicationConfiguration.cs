using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ServerSoftwareApplicationConfiguration : IEntityTypeConfiguration<ServerSoftwareApplication>
    {
        public void Configure(EntityTypeBuilder<ServerSoftwareApplication> builder)
        {
            builder.ToTable("ServerSoftwareApplications");

            builder
                .HasOne(serverSoftwareApplication => serverSoftwareApplication.Server)
                .WithMany(server => server.InstalledSoftwareApplications)
                .HasForeignKey(serverSoftwareApplication => serverSoftwareApplication.ServerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(serverSoftwareApplication => serverSoftwareApplication.SoftwareApplication)
                .WithMany(softwareApplication => softwareApplication.Servers)
                .HasForeignKey(serverSoftwareApplication => serverSoftwareApplication.SoftwareApplicationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
