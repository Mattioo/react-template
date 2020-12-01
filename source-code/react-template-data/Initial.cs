using EnumStringValues;
using Hangfire;
using Hangfire.PostgreSql;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using react_template_data.Data;
using react_template_data.Enums;
using react_template_data.IoC;
using react_template_data.Repositories.Master;
using Scrutor;
using System;
using System.IO;

namespace react_template_data
{
    public static class Initial
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static readonly IConfiguration ConfigurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template-data", "appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template-data", $"appsettings.{Env}.json"), true)
            .Build();

        public static IServiceCollection AddHangfire(this IServiceCollection services)
        {
            return services.AddHangfire(config =>
                config.UsePostgreSqlStorage(ConnectionString(ConnectionStringType.Master))
            );
        }

        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            /* REJESTRACJA W KONTENERZE DI SERWISU UMOŻLIWIAJĄCEGO DOSTĘP DO KONTEKSTU HTTP */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            /* REJESTRACJA W KONTENERZE DI NIEZMIENNEGO KONTEKSTU BAZY MASTER */
            services.AddDbContext<MasterContext>(ctx => ctx.UseNpgsql(ConnectionString(ConnectionStringType.Master)),
                ServiceLifetime.Singleton
            );

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU MASTER */
            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(t => t.AssignableTo(typeof(IMasterContextRepository)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithSingletonLifetime()
            );

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU BAZY OWNER ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<OwnerContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(ConnectionString(ConnectionStringType.Owner, serviceProvider));
            },
            ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU IDENTITY ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<IdentityContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(ConnectionString(ConnectionStringType.Owner, serviceProvider));
            },
            ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU OWNER */
            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(t => t.AssignableTo(typeof(IOwnerContextRepository)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithScopedLifetime()
            );

            return services;
        }

        public static string ConnectionString(ConnectionStringType connectionStringType, IServiceProvider serviceProvider = null)
        {
            var builder = new NpgsqlConnectionStringBuilder(ConfigurationBuilder.GetConnectionString(EnumExtensions.GetStringValue(connectionStringType)));
            if (connectionStringType is ConnectionStringType.Owner && serviceProvider is IServiceProvider)
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                if (httpContext is HttpContext)
                {
                    var host = new Uri(httpContext.Request.GetEncodedUrl()).Host;
                    var repository = serviceProvider.GetService<UnitsRepository>();
                    var database = repository.Get(u => u.Path == host, default).Result?.Database;

                    builder.Database = database;
                }
            }           

            return builder.ConnectionString;
        }

        public static T GenerateConstantContext<T>() where T : DbContext
        {
            var connectionString = ConnectionString(ConnectionStringType.Master);
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseNpgsql(connectionString);

            return (T) Activator.CreateInstance(typeof(T), builder.Options, typeof(T) == typeof(ConfigurationContext) ?
                (object) new ConfigurationStoreOptions
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
