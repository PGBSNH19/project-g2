using KNet.API.Models;
using KNet.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KNet.API.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        AzureKeyVaultService _aKVService = new AzureKeyVaultService();

        public AppDbContext(IConfiguration config, DbContextOptions<AppDbContext> options) : base(options)
        {
            _configuration = config;
        }

        public AppDbContext()
        {

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();

            try
            {
                builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var config = builder.Build();
                var defaultConnectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(defaultConnectionString);

            }
            catch
            {
                var azureDbCon = _aKVService.GetKeyVaultSecret("https://knetkeys.vault.azure.net/secrets/knetconnectionstring/c08543c15e6f47abb0089993d6a83ac2");
                optionsBuilder.UseSqlServer(azureDbCon);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public override Task<int> SaveChangesAsync(
                    bool acceptAllChangesOnSuccess,
                    CancellationToken token = default)
        {
            var changeTracker = ChangeTracker.Entries()
                .Where(x => x.Entity is Entity && x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .Cast<Entity>();

            foreach (var entity in changeTracker)
            {
                entity.Modified = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                entity.Version++;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, token);
        }

    }
}
