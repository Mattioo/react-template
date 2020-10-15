﻿using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using react_template_data.Data;
using react_template_data.IoC;
using react_template_data.Repositories.Master;
using Scrutor;
using System;
using System.IO;

namespace react_template_data
{
    public static class Registration
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static readonly IConfiguration ConfigurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template-data", "appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "react-template-data", $"appsettings.{Env}.json"), true)
            .Build();

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            /* REJESTRACJA W KONTENERZE DI SERWISU UMOŻLIWIAJĄCEGO DOSTĘP DO KONTEKSTU HTTP */
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            /* REJESTRACJA W KONTENERZE DI NIEZMIENNEGO KONTEKSTU BAZY MASTER */
            services.AddDbContext<MasterContext>(ctx => ctx.UseNpgsql(ConfigurationBuilder.GetConnectionString("master")), ServiceLifetime.Transient);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU MASTER */
            services.Scan(scan => scan.FromAssemblyOf<IMasterContextRepository>()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithTransientLifetime()
            );

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU BAZY OWNER ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<OwnerContext>((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                if (httpContext is HttpContext)
                {
                    var host = new Uri(httpContext.Request.GetEncodedUrl()).GetLeftPart(UriPartial.Authority);
                    var repository = serviceProvider.GetService<ClientsRepository>();
                    var client = repository.Get(u => u.Path == host, default);
                    var builder = new NpgsqlConnectionStringBuilder(ConfigurationBuilder.GetConnectionString("owner"))
                    {
                        Database = client.Result?.Database
                    };

                    options.UseNpgsql(builder.ConnectionString);
                }
            },
            ServiceLifetime.Transient);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU OWNER */
            services.Scan(scan => scan.FromAssemblyOf<IOwnerContextRepository>()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithTransientLifetime()
            );

            return services;
        }

        public static IServiceCollection AddHangfire(this IServiceCollection services)
       {
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(ConfigurationBuilder.GetConnectionString("master"))
            );
            return services;
        }
    }
}
