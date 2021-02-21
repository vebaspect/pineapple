using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace Pineapple.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateLogger();

            try
            {
                Log.Debug("Pineapple Api is starting...");

                CreateHostBuilder(args).Build().Run();

                Log.Debug("Pineapple Api has been stopped.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Pineapple Api has not been started.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void CreateLogger()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            LoggerConfiguration logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithExceptionDetails()
                .WriteTo.Console();

            IConfigurationSection loggerConfigurationSection = configuration.GetSection("Logger");
            if (loggerConfigurationSection.GetValue<bool>("File:Enabled"))
            {
                logger.WriteTo.File("logs/log.txt",
                    fileSizeLimitBytes: null,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    retainedFileCountLimit: 50,
                    rollingInterval: RollingInterval.Day);
            }

            Log.Logger = logger.CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel((context, config) => config.Listen(IPAddress.Any, context.Configuration.GetSection("Hosting:Port").Get<int>()));
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
