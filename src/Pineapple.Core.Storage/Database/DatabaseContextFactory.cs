using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pineapple.Core.Storage.Exceptions;

namespace Pineapple.Core.Storage.Database
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public DatabaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("storagesettings.json")
                .Build();

            string databaseType = configuration.GetValue<string>("Database:Type");
            string databaseConnectionString = configuration.GetValue<string>("Database:ConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            switch (databaseType)
            {
                case "PostgreSQL":
                    optionsBuilder.UseNpgsql(
                        databaseConnectionString,
                        options => options.MigrationsHistoryTable("__EFMigrationsHistory", "pineapple")
                    );
                    break;
                case "SqlServer":
                    optionsBuilder.UseSqlServer(
                        databaseConnectionString,
                        options => options.MigrationsHistoryTable("__EFMigrationsHistory", "pineapple")
                    );
                    break;
                default:
                    throw new StorageSettingsException($"Database type ${databaseType} is invalid");
            }

            optionsBuilder.EnableSensitiveDataLogging();

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
