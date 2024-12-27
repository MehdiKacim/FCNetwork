using FCNetwork.Infrastructure.Entities;
using FCNetwork.Infrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FCNetwork.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Player> Players { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important to keep this line

            modelBuilder.Entity<Device>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd(); // This is the key part
            modelBuilder.Entity<Player>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd(); // This is the key part
        }
    }
}
