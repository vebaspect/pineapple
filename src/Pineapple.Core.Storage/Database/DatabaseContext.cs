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
        /// Wersje komponentów.
        /// </summary>
        public DbSet<ComponentVersion> ComponentVersions { get; set; }

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
        /// Logi.
        /// </summary>
        public DbSet<Log> Logs { get; set; }

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
        /// Oprogramowanie.
        /// </summary>
        public DbSet<SoftwareApplication> SoftwareApplications { get; set; }

        /// <summary>
        /// Użytkownicy.
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new AdministratorConfiguration())
                .ApplyConfiguration(new ComponentConfiguration())
                .ApplyConfiguration(new ComponentLogConfiguration())
                .ApplyConfiguration(new ComponentTypeConfiguration())
                .ApplyConfiguration(new ComponentVersionConfiguration())
                .ApplyConfiguration(new ComponentVersionLogConfiguration())
                .ApplyConfiguration(new CoordinatorConfiguration())
                .ApplyConfiguration(new DeveloperConfiguration())
                .ApplyConfiguration(new EnvironmentConfiguration())
                .ApplyConfiguration(new EnvironmentLogConfiguration())
                .ApplyConfiguration(new ImplementationConfiguration())
                .ApplyConfiguration(new ImplementationLogConfiguration())
                .ApplyConfiguration(new LogConfiguration())
                .ApplyConfiguration(new ManagerConfiguration())
                .ApplyConfiguration(new OperatingSystemConfiguration())
                .ApplyConfiguration(new OperatorConfiguration())
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new ProductLogConfiguration())
                .ApplyConfiguration(new ServerConfiguration())
                .ApplyConfiguration(new ServerLogConfiguration())
                .ApplyConfiguration(new SoftwareApplicationConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserLogConfiguration());

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
            modelBuilder
                .Entity<SoftwareApplication>()
                .HasIndex(softwareApplication => softwareApplication.Symbol)
                .IsUnique();
            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Login)
                .IsUnique();
        }
    }
}
