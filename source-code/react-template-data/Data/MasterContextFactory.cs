using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace react_template_data.Data
{
    public class MasterContextFactory : IDesignTimeDbContextFactory<MasterContext>
    {
        public MasterContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template", "appsettings.json"))
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template", $"appsettings.{environment}.json"), optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<MasterContext>();
            var connectionString = configuration.GetConnectionString("master");
            builder.UseNpgsql(connectionString);

            return new MasterContext(builder.Options);
        }
    }
}
