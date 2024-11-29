using Microsoft.EntityFrameworkCore;
using InsuranceCoverageBrowser.Models;

namespace InsuranceCoverageBrowser.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Price).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Kitchen" }
            );

            // Seeding Items
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "TV", CategoryId = 1, Price = 2000m },
                new Item { Id = 2, Name = "Playstation", CategoryId = 1, Price = 400m },
                new Item { Id = 3, Name = "Stereo", CategoryId = 1, Price = 1600m },
                new Item { Id = 4, Name = "Shirts", CategoryId = 2, Price = 1100m },
                new Item { Id = 5, Name = "Jeans", CategoryId = 2, Price = 1100m },
                new Item { Id = 6, Name = "Pots and Pans", CategoryId = 3, Price = 3000m },
                new Item { Id = 7, Name = "Flatware", CategoryId = 3, Price = 500m },
                new Item { Id = 8, Name = "Knife Set", CategoryId = 3, Price = 500m },
                new Item { Id = 9, Name = "Misc", CategoryId = 3, Price = 1000m }
            );
        }
    }
}