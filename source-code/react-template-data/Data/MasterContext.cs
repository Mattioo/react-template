using Microsoft.EntityFrameworkCore;
using react_template_data.Data.Master;
using react_template_data.Models.Configurations.Master;

namespace react_template_data.Data
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        { }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<BackgroundJob> BackgroundJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {     
            builder.ApplyConfiguration(new UnitConfiguration());
            builder.ApplyConfiguration(new StyleConfiguration());
            builder.ApplyConfiguration(new UrlConfiguration());
            builder.ApplyConfiguration(new BackgroundJobConfiguration());
        }
    }
}
