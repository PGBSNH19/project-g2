using KNet.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KNet.API.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

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
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
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
