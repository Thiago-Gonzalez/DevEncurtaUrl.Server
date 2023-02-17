using System.Reflection;
using DevEncurtaUrl.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevEncurtaUrl.Infrastructure.Persistence
{
    public class DevEncurtaUrlDbContext : DbContext
    {
        public DevEncurtaUrlDbContext(DbContextOptions<DevEncurtaUrlDbContext> options) : base(options)
        {
        }

        public DbSet<ShortenedCustomLink> ShortenedLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedCustomLink>(e => {
                e.HasKey(l => l.Id);
            });
        }
    }
}