using EnumStringValues;
using Hangfire;
using Hangfire.PostgreSql;
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
                config.UsePostgreSqlStorage(ConfigurationBuilder.GetConnectionString("master"))
            );
        }

        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            /* REJESTRACJA W KONTENERZE DI SERWISU UMOŻLIWIAJĄCEGO DOSTĘP DO KONTEKSTU HTTP */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            /* REJESTRACJA W KONTENERZE DI NIEZMIENNEGO KONTEKSTU BAZY MASTER */
            services.AddDbContext<MasterContext>(ctx => ctx.UseNpgsql(ConfigurationBuilder.GetConnectionString("master")),
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
            services.AddDbContext<OwnerContext>(OwnerContextGenerator, ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU IDENTITY ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<IdentityContext>(OwnerContextGenerator, ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU OWNER */
            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(t => t.AssignableTo(typeof(IOwnerContextRepository)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithScopedLifetime()
            );

            return services;
        }

        public static string ConnectionString(IServiceProvider serviceProvider, ConnectionStringType connectionStringType = ConnectionStringType.Master)
        {
            var builder = new NpgsqlConnectionStringBuilder(ConfigurationBuilder.GetConnectionString(EnumExtensions.GetStringValue(connectionStringType)));
            if (connectionStringType is ConnectionStringType.Owner)
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

        private static readonly Action<IServiceProvider, DbContextOptionsBuilder> OwnerContextGenerator = (serviceProvider, options) =>
        {
            options.UseNpgsql(ConnectionString(serviceProvider, ConnectionStringType.Owner));
        };
    }
}
