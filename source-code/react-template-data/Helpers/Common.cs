using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using react_template_data.Data;
using react_template_data.Enums;
using System;

namespace react_template_data.Helpers
{
    public static class Common
    {
        public static string GetHost(this HttpContext context)
            => new Uri(context.Request.GetEncodedUrl()).GetLeftPart(UriPartial.Authority);

        public static T GenerateMasterContext<T>() where T : DbContext
        {
            var connectionString = Initial.ConnectionString(ConnectionStringType.Master);

            var builder = new DbContextOptionsBuilder<T>();
            builder.UseNpgsql(connectionString);

            return (T)Activator.CreateInstance(typeof(T), builder.Options, typeof(T) == typeof(ConfigurationContext) ?
                (object)new ConfigurationStoreOptions
                {
                    ConfigureDbContext = builder => builder.UseNpgsql(connectionString)
                } :
                new OperationalStoreOptions
                {
                    ConfigureDbContext = builder => builder.UseNpgsql(connectionString)
                }
            );
        }
    }
}
