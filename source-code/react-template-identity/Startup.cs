using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace react_template_identity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients())
                .AddInMemoryIdentityResources(Config.Resources())
                .AddInMemoryApiResources(Config.ApiResources())
                .AddInMemoryApiScopes(Config.Scopes())
                .AddTestUsers(Config.Users())
                .AddDeveloperSigningCredential();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
