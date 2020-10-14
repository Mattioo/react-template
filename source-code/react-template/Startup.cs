using DinkToPdf;
using DinkToPdf.Contracts;
using Hangfire;
using Hangfire.PostgreSql;
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
using react_template.IoC;
using react_template.Properties.Options;
using react_template.Services;
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
                .WithTransientLifetime()
            );

            #region Rejestracja bilbioteki generuj¹cej pliki PDF
            var pdfOptions = Configuration.GetSection(PdfOptions.Name);
            services.Configure<PdfOptions>(pdfOptions);

            var pdfLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "libs", "libwkhtmltox", "libwkhtmltox");
            NativeLibrary.Load(pdfLibraryPath);

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            /* REJESTRACJA W KONTENERZE DI SERWISU UMO¯LIWIAJ¥CEGO DOSTÊP DO KONTEKSTU HTTP */
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            /* REJESTRACJA W KONTENERZE DI SERWISU ZAJMUJ¥CEGO SIÊ OBS£UG¥ STYLI */
            services.AddTransient<IStylesService, StylesService>();
            /* REJESTRACJA W KONTENERZE DI SERWISU ZAJMUJ¥CEGO SIÊ OBS£UG¥ PLIKÓW PDF */
            services.AddTransient<IPdfService, PdfService>();

            /* REJESTRACJA W KONTENERZE DI ZMIENNEGO KONTEKSTU BAZY OWNER ZALE¯NEGO OD HOSTA W ADRESIE ¯¥DANIA */
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
            ServiceLifetime.Transient);

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW KONTEKSTU OWNER */
            services.Scan(scan => scan.FromAssemblyOf<IOwnerContextRepository>()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithTransientLifetime()
            );

            services.AddControllers();

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
                options.DefaultScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("cookie")
            .AddOpenIdConnect("oidc", options =>
            {
                options.ClientId = Assembly.GetExecutingAssembly().GetName().Name;

                options.Authority = identityOptions.GetValue<string>("Address");
                options.Scope.Add(identityOptions.GetValue<string>("Scope"));
                options.ClientSecret = identityOptions.GetValue<string>("Secret");

                options.ResponseType = "code";
                options.ResponseMode = "query";
                
                options.SaveTokens = true;
                options.UsePkce = true;
            });

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
