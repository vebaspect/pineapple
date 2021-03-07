using Pineapple.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Core.Storage.Database.Configurations
{
    internal class ProductLogConfiguration : IEntityTypeConfiguration<ProductLog>
    {
        public void Configure(EntityTypeBuilder<ProductLog> builder)
        {
        }
    }
}
