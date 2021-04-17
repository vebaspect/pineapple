using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder
                .Property(product => product.ModificationDate)
                .IsRequired();
            builder
                .Property(product => product.IsDeleted)
                .IsRequired();
            builder
                .Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(product => product.Description)
                .HasMaxLength(4000);
            builder
                .HasMany(product => product.EntityLogs)
                .WithOne(log => log.Product)
                .HasForeignKey(log => log.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
