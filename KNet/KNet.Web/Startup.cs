using KNet.Web.Controllers;
using MatBlazor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace KNet.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string stagingURI = @"http://group2api-staging.westus.azurecontainer.io/api/v1/";
        string releaseURI = @"http://group2api-release.westus.azurecontainer.io/api/v1/";
        string localURI = @"https://localhost:44360/api/v1/";

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
#if DEBUG
            // To run locally:
            // services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new Uri(localURI));

            services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new Uri(stagingURI));

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
