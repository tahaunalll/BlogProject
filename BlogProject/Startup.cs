using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Buradan itibaren

            //oturum ekleme?  session üzerinden de sisteme authenticate olunabilirdi..
            //services.AddSession();

            //Proje Seviyesinde Authorize Attr Kullanabilmek için:
            services.AddMvc(config =>
            {
                //using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                //using Microsoft.AspNetCore.Mvc.Authorization;
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            //Farklı bir route a yönlendirmeye izin vermeyecek login sayfasında kalacak : 
            //using Microsoft.AspNetCore.Authentication.Cookies;
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x=>
                {
                    x.LoginPath = "/Login/Index";
                });
            //Buraya kadar..
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Buradan itibaren:

            //routing yanlıs oldugunuda 404 not found gibi..
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");


            //Buraya kadar..
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Buradan  Authentication için
            //app.UseSession(); --> session ile authenticate seçeneği var biz farklı authentication seçtik
            app.UseAuthentication();
            //Buraya kadar..

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
