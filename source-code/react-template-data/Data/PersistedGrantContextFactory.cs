using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace react_template_data.Data
{
    public class PersistedGrantContextFactory : IDesignTimeDbContextFactory<PersistedGrantContext>
    {
        public PersistedGrantContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PersistedGrantContext>();
            var connectionString = Initial.ConfigurationBuilder.GetConnectionString("master");

            builder.UseNpgsql(connectionString);

            var configStoreOptions = new OperationalStoreOptions
            {
                ConfigureDbContext = builder => builder.UseNpgsql(connectionString)
            };

            return new PersistedGrantContext(builder.Options, configStoreOptions);
        }
    }
}