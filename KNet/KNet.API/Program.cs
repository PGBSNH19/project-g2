using KNet.API.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Trying Initialization");
                try
                {
                    var initializer = new DbInitializer();

                    initializer.Initialize(context);
                    logger.LogInformation("Context initialized.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
