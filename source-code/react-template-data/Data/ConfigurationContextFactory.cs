using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace react_template_data.Data
{
    public class ConfigurationContextFactory : IDesignTimeDbContextFactory<ConfigurationContext>
    {
        public ConfigurationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConfigurationContext>();
            var connectionString = Initial.ConfigurationBuilder.GetConnectionString("master");

            builder.UseNpgsql(connectionString);

            var configStoreOptions = new ConfigurationStoreOptions
            {
                ConfigureDbContext = builder => builder.UseNpgsql(connectionString)
            };

            return new ConfigurationContext(builder.Options, configStoreOptions);
        }
    }
}