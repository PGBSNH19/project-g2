using KNet.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using System.Net.Http;
using KNet.Web.Controllers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

namespace KNet.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string stagingURI = @"https://G2api-staging-run6.westus.azurecontainer.io/api/v1/";
        string releaseURI = @"https://G2api-release-run5.westus.azurecontainer.io/api/v1/";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #if DEBUG
            {
                services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new Uri(stagingURI));
            }
            #else
            {
                services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new Uri(releaseURI));
            }
            #endif            
            services.AddScoped<AdvertController>();
            services.AddScoped<UserController>();

            services.AddAuthentication("Identity.Application")
                .AddCookie();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMatBlazor();
            services.AddRazorPages();

            // HttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
