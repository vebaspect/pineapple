using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ServerComponentConfiguration : IEntityTypeConfiguration<ServerComponent>
    {
        public void Configure(EntityTypeBuilder<ServerComponent> builder)
        {
            builder.ToTable("ServerComponents");

            builder
                .HasOne(serverComponent => serverComponent.Server)
                .WithMany(server => server.InstalledComponents)
                .HasForeignKey(serverComponent => serverComponent.ServerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(serverComponent => serverComponent.ComponentVersion)
                .WithMany(componentVersion => componentVersion.Servers)
                .HasForeignKey(serverComponent => serverComponent.ComponentVersionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
