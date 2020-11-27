using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace react_template_data.Data
{
    public class ConfigurationContext : ConfigurationDbContext<ConfigurationContext>
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        { }
    }
}
