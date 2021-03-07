using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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

            string connectionString = configuration.GetValue<string>("ConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
