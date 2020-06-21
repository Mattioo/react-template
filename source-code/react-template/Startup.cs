using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using react_template.Properties.Options;
using react_template_data.Data;
using react_template_data.IoC;
using Scrutor;

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
            services.AddDbContext<MasterContext>(ctx => ctx.UseNpgsql(Configuration.GetConnectionString("master")));

            /* REJESTRACJA W KONTENERZE DI WSZYSTKICH REPOZYTORIÓW DZIEDZICZĄCYCH PO BASEREPOSITORY */
            services.Scan(scan => scan.FromAssemblyOf<IBaseRepository>()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithTransientLifetime()
            );

            services.Configure<StylesOptions>(Configuration.GetSection(StylesOptions.Name));
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
            services.AddControllers();

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
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "React-Template API v1");
            });

            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1
            });

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute
            { 
                Attempts = 0
            });

            app.UseRouting();

            app.UseCors(_frontOfficeCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
