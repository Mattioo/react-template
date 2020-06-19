using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace react_template_data.Data
{
    public class MasterContextFactory : IDesignTimeDbContextFactory<MasterContext>
    {
        public MasterContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template", "appsettings.json"))
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template", "appsettings.Development.json"))
                .Build();

            var builder = new DbContextOptionsBuilder<MasterContext>();
            var connectionString = configuration.GetConnectionString("master");
            builder.UseNpgsql(connectionString);

            return new MasterContext(builder.Options);
        }
    }
}
