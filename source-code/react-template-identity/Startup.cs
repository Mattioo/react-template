using IdentityServer4.Configuration;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using react_template_data;
using react_template_data.Data;
using react_template_data.Data.IS;
using react_template_data.Enums;
using react_template_data.Repositories.Identity;
using System;
using System.Linq;

namespace react_template_identity
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContext();

            services.AddSingleton(serviceProvider => Initial.GenerateConstantContext<PersistedGrantContext>());
            services.AddSingleton(serviceProvider => Initial.GenerateConstantContext<ConfigurationContext>());

            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                })
                .AddUserManager<UserRepository>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            var assembly = typeof(Initial).Assembly.GetName().Name;

            services.AddIdentityServer(options =>
            {
                options.Events = new EventsOptions
                {
                    RaiseErrorEvents = true,
                    RaiseInformationEvents = true,
                    RaiseFailureEvents = true,
                    RaiseSuccessEvents = true,
                };
                options.Authentication.CheckSessionCookieName = "react-template.session";
                options.Authentication.CookieLifetime = TimeSpan.FromMinutes(60);
                options.Authentication.CookieSlidingExpiration = true;
            })
            .AddConfigurationStore(option =>
                option.ConfigureDbContext = dbContextBuilder => dbContextBuilder.UseNpgsql(
                    Initial.ConnectionString(ConnectionStringType.Master),
                    options => options.MigrationsAssembly(assembly)
                )
            )
            .AddOperationalStore(option =>
                option.ConfigureDbContext = dbContextBuilder => dbContextBuilder.UseNpgsql(
                    Initial.ConnectionString(ConnectionStringType.Master),
                    options => options.MigrationsAssembly(assembly)
                )
            )
            .AddAspNetIdentity<User>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseIdentityServer();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            var persistedGrantContext = scope.ServiceProvider.GetRequiredService<PersistedGrantContext>();
            var configurationContext = scope.ServiceProvider.GetRequiredService<ConfigurationContext>();

            persistedGrantContext.Database.Migrate();
            configurationContext.Database.Migrate();

            if (!configurationContext.Clients.Any())
            {
                foreach (var client in Config.Clients())
                {
                    configurationContext.Clients.Add(client.ToEntity());
                }
                configurationContext.SaveChanges();
            }

            if (!configurationContext.IdentityResources.Any())
            {
                foreach (var resource in Config.Resources())
                {
                    configurationContext.IdentityResources.Add(resource.ToEntity());
                }
                configurationContext.SaveChanges();
            }

            if (!configurationContext.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources())
                {
                    configurationContext.ApiResources.Add(resource.ToEntity());
                }
                configurationContext.SaveChanges();
            }
        }
    }
}
