using DinkToPdf;
using DinkToPdf.Contracts;
using Hangfire;
using Hangfire.PostgreSql;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Npgsql;
using react_template.Properties.Options;
using react_template_data.Data;
using react_template_data.IoC;
using react_template_data.Repositories.Master;
using Scrutor;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace react_template
{
    public class Startup
    {
        private readonly string _frontOfficeCors = "_frontOfficeCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* REJESTRACJA W KONTENERZE DI NIEZMIENNEGO KONTEKSTU BAZY MASTER */
            services.AddDbContext<MasterContext>(ctx => ctx.UseNpgsql(Configuration.GetConnectionString("master")), ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU MASTER */
            services.Scan(scan => scan.FromAssemblyOf<IMasterContextRepository> ()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithScopedLifetime()
            );

            /* REJESTRACJA W KONTENERZE DI SERWISU UMOŻLIWIAJĄCEGO DOSTĘP DO KONTEKSTU HTTP */
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU BAZY OWNER ZALEŻNEGO OD HOSTA W ADRESIE ŻĄDANIA */
            services.AddDbContext<OwnerContext>((serviceProvider, options) =>
            {
                var host = new Uri(serviceProvider.GetService<IHttpContextAccessor>().HttpContext.Request.GetEncodedUrl()).GetLeftPart(UriPartial.Authority);
                var repository = serviceProvider.GetService<ClientsRepository>();
                var client = repository.Get(u => u.Path == host, default);
                var builder = new NpgsqlConnectionStringBuilder(Configuration.GetConnectionString("owner"))
                {
                    Database = client.Result?.Database
                };

                options.UseNpgsql(builder.ConnectionString);
            },
            ServiceLifetime.Scoped);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU OWNER */
            services.Scan(scan => scan.FromAssemblyOf<IOwnerContextRepository>()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithScopedLifetime()
            );

            #region PDF
            var pdfOptions = Configuration.GetSection(PdfOptions.Name);
            services.Configure<PdfOptions>(pdfOptions);

            var pdfLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "libs", "libwkhtmltox", "libwkhtmltox");
            NativeLibrary.Load(pdfLibraryPath);

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            var identityOptions = Configuration.GetSection("IdentityOptions");

            services.AddCors(options =>
            {
                options.AddPolicy(name: _frontOfficeCors,
                builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("cors").Get<string[]>())
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "https://localhost:44377";

                options.ClientId = "react-template";
                options.ClientSecret = "P@ssw0rd";
                options.ResponseType = "code";

                options.SaveTokens = true;

                options.Scope.Add("identity-scope");
            });

            services.AddControllers().AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "React-Template API", Version = "v1" });
                c.EnableAnnotations();
            });

            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(Configuration.GetConnectionString("master"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "React-Template API v1");
            });
            #endregion
            #region Hangfire
            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1
            });

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute
            {
                Attempts = 0
            });
            #endregion

            app.UseCors(_frontOfficeCors);
            app.UseRouting();
       
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
