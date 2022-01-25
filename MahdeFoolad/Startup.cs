using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedFrameWork;
using SharedFrameWork.Application;
using Microsoft.AspNetCore.Razor.Runtime;


namespace MahdeFoolad
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }
        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterSharedFrameworkService(Configuration.GetConnectionString("DefaultConnection"));
            object p = services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IContextHelper mongohelper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("AdminArea", "Admin", "{area:exists}/{controller}/{action}/{Id?}");
                endpoints.MapAreaControllerRoute("UserAera", "User", "{area:exists}/{controller}/{action}/{Id?}");

                endpoints.MapControllerRoute(
                    name: "Default",
                     pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
