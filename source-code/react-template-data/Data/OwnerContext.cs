using Microsoft.EntityFrameworkCore;
using react_template_data.Data.Owner;
using react_template_data.Models.Configurations.Master;

namespace react_template_data.Data
{
    public class OwnerContext : DbContext
    {
        public OwnerContext(DbContextOptions<OwnerContext> options) : base(options)
        { }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PropertyConfiguration());
        }
    }
}
