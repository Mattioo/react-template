using Microsoft.EntityFrameworkCore;
using react_template_data.Data.Master;
using react_template_data.Models.Configurations.Master;

namespace react_template_data.Data
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<BackgroundJob> BackgroundJobs { get; set; }
        public DbSet<Scope> Scopes { get; set; }
        public DbSet<RedirectUri> RedirectUris { get; set; }
        public DbSet<GrantType> GrantTypes { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<DomainSystem> DomainSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {     
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new StyleConfiguration());
            builder.ApplyConfiguration(new UrlConfiguration());
            builder.ApplyConfiguration(new BackgroundJobConfiguration());
            builder.ApplyConfiguration(new ScopeConfiguration());
            builder.ApplyConfiguration(new RedirectUriConfiguration());
            builder.ApplyConfiguration(new GrantTypeConfiguration());
            builder.ApplyConfiguration(new IdentityResourceConfiguration());
            builder.ApplyConfiguration(new DomainSystemConfiguration());
        }
    }
}
