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
        /// Typy komponentów.
        /// </summary>
        public DbSet<ComponentType> ComponentTypes { get; set; }

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
        /// Systemy operacyjne.
        /// </summary>
        public DbSet<OperatingSystem> OperatingSystems { get; set; }

        /// <summary>
        /// Produkty.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Serwery.
        /// </summary>
        public DbSet<Server> Servers { get; set; }

        /// <summary>
        /// Wersje.
        /// </summary>
        public DbSet<Version> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ComponentConfiguration())
                .ApplyConfiguration(new ComponentTypeConfiguration())
                .ApplyConfiguration(new CoordinatorConfiguration())
                .ApplyConfiguration(new EnvironmentConfiguration())
                .ApplyConfiguration(new ImplementationConfiguration())
                .ApplyConfiguration(new OperatingSystemConfiguration())
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new ServerConfiguration())
                .ApplyConfiguration(new VersionConfiguration());

            modelBuilder
                .Entity<ComponentType>()
                .HasIndex(componentType => componentType.Symbol)
                .IsUnique();
            modelBuilder
                .Entity<Environment>()
                .HasIndex(environment => environment.Symbol)
                .IsUnique();
            modelBuilder
                .Entity<OperatingSystem>()
                .HasIndex(operatingSystem => operatingSystem.Symbol)
                .IsUnique();
            modelBuilder
                .Entity<Server>()
                .HasIndex(server => server.Symbol)
                .IsUnique();
        }
    }
}
