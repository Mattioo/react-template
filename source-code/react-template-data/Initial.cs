using EnumStringValues;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using react_template_data.Data;
using react_template_data.Enums;
using react_template_data.Helpers;
using react_template_data.IoC;
using react_template_data.IoC.Master;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace react_template_data
{
    public static class Initial
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static readonly IConfiguration ConfigurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template-data", "appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template-data", $"appsettings.{Env}.json"), true)
            .Build();

        public static IServiceCollection RegisterInContainer(this IServiceCollection services)
        {
            /* REJESTRACJA W KONTENERZE DI SERWISU UMOŻLIWIAJĄCEGO DOSTĘP DO KONTEKSTU HTTP */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            /* REJESTRACJA W KONTENERZE DI NIEZMIENNEGO KONTEKSTU BAZY MASTER */
            services.AddDbContext<MasterContext>(ctx => ctx.UseNpgsql(ConnectionString(ConnectionStringType.Master).GetAwaiter().GetResult()));

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU MASTER */
            services.Register(typeof(IMasterRepository<>), ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU BAZY OWNER ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<OwnerContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(ConnectionString(ConnectionStringType.Owner, serviceProvider).GetAwaiter().GetResult());
            });

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU OWNER */
            services.Register(typeof(IOwnerRepository<>), ServiceLifetime.Scoped);

            return services;
        }

        public static IServiceCollection RegisterInIdentityServerContainer(this IServiceCollection services)
        {
            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU IDENTITY ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<IdentityContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(ConnectionString(ConnectionStringType.Owner, serviceProvider).GetAwaiter().GetResult());
            });

            /* REJESTRACJA W KONTENERZE DI KONTEKSTÓW DB DLA KONFIGURACJI IDENTITYSERVER4 */
            services.AddScoped(serviceProvider =>
                Common.GenerateMasterContext<PersistedGrantContext>()
            );
            services.AddScoped(serviceProvider =>
                Common.GenerateMasterContext<ConfigurationContext>()
            );

            return services;
        }

        public async static Task<string> ConnectionString(ConnectionStringType connectionStringType, IServiceProvider serviceProvider = null)
        {
            if (connectionStringType is ConnectionStringType.Owner && serviceProvider is null)
            {
                throw new Exception("W celu uzyskania dostępu do bazy danych klienta wymagane jest podanie obu parametru IServiceProvider");
            }

            var builder = new NpgsqlConnectionStringBuilder(
                ConfigurationBuilder.GetConnectionString(EnumExtensions.GetStringValue(connectionStringType))
            );

            if (connectionStringType is ConnectionStringType.Owner)
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                if (httpContext is HttpContext)
                {
                    var host = httpContext.GetHost();
                    var repository = serviceProvider.GetService<IUnitsRepository>();
                    
                    if (repository is IUnitsRepository)
                    {
                        var unit = await repository.Get(u => u.Active && u.Path == host, CancellationToken.None);
                        builder.Database = unit?.Database;
                    }
                }
            }
            return builder.ConnectionString;
        }    
    }
}
