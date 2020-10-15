using DinkToPdf;
using DinkToPdf.Contracts;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using react_template.IoC;
using react_template.Properties.Options;
using react_template.Services;
using react_template_data;
using System.IO;
using System.Runtime.InteropServices;

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
            #endregion
            #region Rejestracja generatora wydruk�w
            var pdfLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "libs", "libwkhtmltox", "libwkhtmltox");
            NativeLibrary.Load(pdfLibraryPath);

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            /* REJESTRACJA W KONTENERZE DI SERWISU ZAJMUJ�CEGO SI� OBS�UG� STYLI */
            services.AddTransient<IStylesService, StylesService>();
            /* REJESTRACJA W KONTENERZE DI SERWISU ZAJMUJ�CEGO SI� OBS�UG� PLIK�W PDF */
            services.AddTransient<IPdfService, PdfService>();

            services.Repositories();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
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
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "React-Template API", Version = "v1" });
                c.EnableAnnotations();
            });

            services.Hangfire();
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
        }
    }
}
