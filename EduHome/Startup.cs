using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EduhomeDbContext>(opt=>opt.UseSqlServer(_config.GetConnectionString("MyDatabase")));
            services.AddIdentity<AppUser,IdentityRole>(opt=>
            {
                //opt.SignIn.RequireConfirmedEmail = true;
                //opt.SignIn.RequireConfirmedPhoneNumber = true;                
                //opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EduhomeDbContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=home}/{action=index}/{id?}"
                   );

            });
        }
    }
}
