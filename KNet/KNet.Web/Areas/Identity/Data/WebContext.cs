using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KNet.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KNet.Web.Data
{
    public class WebContext : IdentityDbContext<User>
    {
        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //var configBuilder = new ConfigurationBuilder();
            //try
            //{
            //    configBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //    var config = configBuilder.Build();
            //    var defaultConnectionString = config.GetConnectionString("DefaultConnection");
            //    optionsBuilder.UseSqlServer(defaultConnectionString);
            //}
            //catch
            //{
            //    var azureDbCon = _aKVService.GetKeyVaultSecret().Result;
            //    optionsBuilder.UseSqlServer(azureDbCon);
            //}
        }
    }
}
