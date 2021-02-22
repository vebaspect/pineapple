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
        /// Koordynatorzy.
        /// </summary>
        public DbSet<Coordinator> Coordinators { get; set; }

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

        /// <summary>
        /// Wersje.
        /// </summary>
        public DbSet<Version> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ComponentConfiguration())
                .ApplyConfiguration(new CoordinatorConfiguration())
                .ApplyConfiguration(new EnvironmentConfiguration())
                .ApplyConfiguration(new ImplementationConfiguration())
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new VersionConfiguration());
        }
    }
}
