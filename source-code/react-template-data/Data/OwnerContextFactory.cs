using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace react_template_data.Data
{
    public class OwnerContextFactory : IDesignTimeDbContextFactory<OwnerContext>
    {
        public OwnerContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OwnerContext>();
            var connectionString = Startup.ConfigurationBuilder.GetConnectionString("owner");
            builder.UseNpgsql(connectionString);

            return new OwnerContext(builder.Options);
        }
    }
}
