using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace react_template_data.Data
{
    public class OwnerContextFactory : IDesignTimeDbContextFactory<OwnerContext>
    {
        public OwnerContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template", "appsettings.json"))
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template", $"appsettings.{environment}.json"), optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<OwnerContext>();
            var connectionString = configuration.GetConnectionString("owner");
            builder.UseNpgsql(connectionString);

            return new OwnerContext(builder.Options);
        }
    }
}
