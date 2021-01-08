using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using react_template_data.Data;
using react_template_data.Enums;
using Scrutor;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace react_template_data.Helpers
{
    public static class Common
    {
        public static string GetHost(this HttpContext context, bool protocol = false)
            => !protocol? context.Request.Host.Host : new Uri(context.Request.GetEncodedUrl()).GetLeftPart(UriPartial.Authority);

        public static T GenerateMasterContext<T>() where T : DbContext
        {
            var connectionString = Initial.ConnectionString(ConnectionStringType.Master).Result;

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

        public static IServiceCollection Register(this IServiceCollection services, Type type, ServiceLifetime serviceLifetime)
        {
            var action = new Action<ITypeSourceSelector>(
                scan =>
                {
                    var selector = scan.FromAssembliesOf(type)
                        .AddClasses(t => t.AssignableTo(type))
                        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                        .AsImplementedInterfaces();

                    switch (serviceLifetime)
                    {
                        case ServiceLifetime.Singleton:
                            selector.WithSingletonLifetime();
                            break;
                        case ServiceLifetime.Scoped:
                            selector.WithScopedLifetime();
                            break;
                        default:
                            selector.WithTransientLifetime();
                            break;
                    }
                }
            );

            services.Scan(action);
            return services;
        }
    }
}
