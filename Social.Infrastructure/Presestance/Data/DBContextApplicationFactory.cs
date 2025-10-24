using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Data
{
    public class DBContextApplicationFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Social.Api");
            // Build configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create DbContextOptionsBuilder with the connection string
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(connectionString);  // Adjust for your database provider

            // Return a new instance of DBContextApplication
            return new ApplicationDBContext(optionsBuilder.Options);
        }
    }
}
