using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QuickKartDataAccessLayer.Models;
using ShopingCartMVC.Repository;
using static ShopingCartMVC.Repository.QuickKartMapper;
using AutoMapper;

namespace ShopingCartMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = Configuration.GetConnectionString("QuickKartCon");
            services.AddDbContext<QuickKartContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QuickKartCon")));
            services.AddAutoMapper(typeof(QuickKartMapper));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; 
            });
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });

        }
    }
}
