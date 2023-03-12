using Microsoft.EntityFrameworkCore;

namespace WebServerAppDev_Final_Project.Models
{
    public class FishContext : DbContext
    {
        public FishContext(DbContextOptions<FishContext> options)
            : base(options)
        { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fish> Fish { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new FishConfig());
        }
    }
}
