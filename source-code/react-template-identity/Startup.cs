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
using System;
using System.Linq;

namespace react_template_identity
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterInIdentityServerContainer();

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
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

            var assembly = typeof(Initial).Assembly.GetName().Name;
            var masterConnectionString = Initial.ConnectionString(ConnectionStringType.Master);

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
                    masterConnectionString,
                    options => options.MigrationsAssembly(assembly)
                )
            )
            .AddOperationalStore(option =>
                option.ConfigureDbContext = dbContextBuilder => dbContextBuilder.UseNpgsql(
                    masterConnectionString,
                    options => options.MigrationsAssembly(assembly)
                )
            )
            .AddAspNetIdentity<User>()
            .AddDeveloperSigningCredential();

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
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            var persistedGrantContext = scope.ServiceProvider
                .GetRequiredService<PersistedGrantContext>();

            persistedGrantContext.Database.Migrate();

            var configurationContext = scope.ServiceProvider
                .GetRequiredService<ConfigurationContext>();
 
            configurationContext.Database.Migrate();

            /* INICJALIZACJA BAZY DANYCH WYKORZYSTUJ¥C DOMYŒLN¥ KONFIGURACJÊ IDENTITYSERVER4 */

            if (!configurationContext.ApiScopes.Any())
            {
                foreach (var apiScope in Config.Scopes())
                {
                    configurationContext.ApiScopes.Add(apiScope.ToEntity());
                }
                configurationContext.SaveChanges();
            }

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
