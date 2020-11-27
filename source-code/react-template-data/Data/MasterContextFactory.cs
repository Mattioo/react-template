using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace react_template_data.Data
{
    public class MasterContextFactory : IDesignTimeDbContextFactory<MasterContext>
    {
        public MasterContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MasterContext>();
            var connectionString = Initial.ConfigurationBuilder.GetConnectionString("master");

            builder.UseNpgsql(connectionString);

            return new MasterContext(builder.Options);
        }
    }
}
