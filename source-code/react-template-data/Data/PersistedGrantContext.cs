using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace react_template_data.Data
{
    public class PersistedGrantContext : PersistedGrantDbContext<PersistedGrantContext>
    {
        public PersistedGrantContext(DbContextOptions<PersistedGrantContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        { }
    }
}
