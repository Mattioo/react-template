using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using react_template_data;
using react_template_data.Repositories.Master;
using System;

namespace react_template_identity
{
    public class Startup
    {
        private IServiceProvider ServiceProvider(IServiceCollection services)
            => services.BuildServiceProvider();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepositories();

            //var clientRepository = ServiceProvider(services).GetService<ClientsRepository>();
            //var client = clientRepository.Get(c => c.Active, default).Result;         

            services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients())
                .AddInMemoryIdentityResources(Config.Resources())
                .AddInMemoryApiScopes(Config.Scopes())
                .AddTestUsers(Config.Users())
                .AddDeveloperSigningCredential();

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
