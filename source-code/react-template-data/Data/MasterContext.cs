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

        protected override void OnModelCreating(ModelBuilder builder)
        {     
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new StyleConfiguration());
            builder.ApplyConfiguration(new UrlConfiguration());
        }
    }
}
