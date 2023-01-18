using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API.Extensions
{
    public class DatabaseSettings
    {
        public string DatabaseType { get; set; }
    }
    
    public static class DatabaseServicesExtensions
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceCollection AddDatabaseServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            Configuration = configuration;
            var databaseSection = Configuration.GetSection("Database");
            services.Configure<DatabaseSettings>(databaseSection);
            var databaseSettings = databaseSection.Get<DatabaseSettings>();

            if (databaseSettings.DatabaseType == "PostGreSql")
            { 
                services.AddDbContext<DataContext, DataContextPostGreSql>(ConfigurePostGreSql);
            }
            else
                Console.WriteLine("Error, Data Type not found");
            return services;
        }

        private static void ConfigurePostGreSql(DbContextOptionsBuilder options)
        {
            string postgresSqlConnectionString = Configuration.GetConnectionString("PostGreSqlConnectionString");
            options.UseNpgsql(postgresSqlConnectionString);
            options.EnableSensitiveDataLogging();
        }

    }
}