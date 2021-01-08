using DinkToPdf;
using DinkToPdf.Contracts;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using react_template.IoC;
using react_template.Properties.Options;
using react_template_data;
using react_template_data.Enums;
using react_template_data.Helpers;
using react_template_notifications.IoC;
using react_template_notifications.Options;
using react_template_notifications.Services;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace react_template
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Rejestracja konfiguracji
            var identityServerSection = Configuration.GetSection(IdentityServerOptions.Name);
            var identityServerOptions = new IdentityServerOptions();
            
            services.Configure<IdentityServerOptions>(identityServerSection);
            identityServerSection.Bind(identityServerOptions);

            var queueSection = Configuration.GetSection(NotificationsOptions.Name);
            services.Configure<NotificationsOptions>(queueSection);
            #endregion
            #region Rejestracja generatora wydruków
            var pdfLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "libs", "libwkhtmltox", "libwkhtmltox");
            NativeLibrary.Load(pdfLibraryPath);

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            services.RegisterInContainer();

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH SERWISÓW */
            services.Register(typeof(IScopeService), ServiceLifetime.Scoped);

            /* REJESTRACJA SERWISU POWIADOMIEÑ */
            services.AddSingleton<INotificationService, NotificationService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
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
                options.Authority = identityServerOptions.Authority;
                options.ClientId = identityServerOptions.Client;
                options.ClientSecret = identityServerOptions.Secret;
                options.Scope.Add(identityServerOptions.Scope);
                options.ResponseType = identityServerOptions.Response;
                options.SaveTokens = true;
                options.Events = new OpenIdConnectEvents
                {
                    OnRemoteFailure = context =>
                    {
                        context.Response.Redirect("/");
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "React-Template API", Version = "v1" });
                c.EnableAnnotations();
            });

            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(Initial.ConnectionString(ConnectionStringType.Master).GetAwaiter().GetResult())
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

            app.UseCors();
            app.UseRouting();
       
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var clientApp = "ClientApp";

            var clientAppDist = new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    @$"{clientApp}\public"
                )
            )};

            app.UseSpaStaticFiles(clientAppDist);
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = clientApp;
                spa.Options.DefaultPageStaticFileOptions = clientAppDist;
                spa.Options.StartupTimeout = TimeSpan.FromSeconds(30);

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
