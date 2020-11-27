using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace react_template_data.Data
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityContext>();
            var connectionString = Initial.ConfigurationBuilder.GetConnectionString("owner");

            builder.UseNpgsql(connectionString);

            return new IdentityContext(builder.Options);
        }
    }
}
