using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using react_template_data;
using react_template_data.Data;
using react_template_data.Data.Identity;
using react_template_data.Repositories.Identity;
using System;

namespace react_template_identity
{
    public class Startup
    {
        private IServiceProvider ServiceProvider(IServiceCollection services)
            => services.BuildServiceProvider();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContext();

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
                    Initial.ConnectionString(ServiceProvider(services)),
                    options => options.MigrationsAssembly(assembly)
                )
            )
            .AddOperationalStore(option =>
                option.ConfigureDbContext = dbContextBuilder => dbContextBuilder.UseNpgsql(
                    Initial.ConnectionString(ServiceProvider(services)),
                    options => options.MigrationsAssembly(assembly)
                )
            )
            .AddAspNetIdentity<User>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
    }
}
