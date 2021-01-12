using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KNet.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using KNet.Web.Areas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KNet.Web.Data
{
    public class WebContext : IdentityDbContext<User>
    {
        AzureKeyVaultService _aKVService = new AzureKeyVaultService();

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder();
            //try
            //{
            //    configBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //    var config = configBuilder.Build();
            //    var defaultConnectionString = config.GetConnectionString("DefaultConnection");
            //    builder.UseSqlServer(defaultConnectionString);
            //}
            //catch
            {
                var azureDbCon = _aKVService.GetKeyVaultSecret().Result;
                builder.UseSqlServer(azureDbCon);
            }
        }
    }
}
