using Pineapple.Core.Domain.Entities;
using Pineapple.Core.Storage.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Pineapple.Core.Storage.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Komponenty.
        /// </summary>
        public DbSet<Component> Components { get; set; }

        /// <summary>
        /// Środowiska.
        /// </summary>
        public DbSet<Environment> Environments { get; set; }

        /// <summary>
        /// Wdrożenia.
        /// </summary>
        public DbSet<Implementation> Implementations { get; set; }

        /// <summary>
        /// Produkty.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ComponentConfiguration())
                .ApplyConfiguration(new EnvironmentConfiguration())
                .ApplyConfiguration(new ImplementationConfiguration())
                .ApplyConfiguration(new ProductConfiguration());
        }
    }
}
