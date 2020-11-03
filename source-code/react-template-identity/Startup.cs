using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using react_template_data;
using react_template_data.Repositories.Master;
using react_template_identity.IoC;
using react_template_identity.Services;
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
            services.AddSingleton<IConfigurationService, ConfigurationService>();

            var configurationService = ServiceProvider(services).GetService<IConfigurationService>();
            var (clients, resources, scopes) = configurationService.GetConfiguration();

            services.AddIdentityServer()
                .AddInMemoryClients(clients)
                .AddInMemoryIdentityResources(resources)
                .AddInMemoryApiScopes(scopes);
                //.AddProfileService<>();

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
