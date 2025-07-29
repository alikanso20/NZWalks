using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty { Id = new Guid("36e7f51c-f4cd-4869-9bb3-fa77b2c5f4f8"), Name = "Easy" },
                new Difficulty { Id = new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"), Name = "Medium" },
                new Difficulty { Id = new Guid("d905c976-6303-45e4-b7ae-a2333549b092"), Name = "Hard" }
            );

            // Seed data for Regions
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = new Guid("1544305d-b597-49cb-829f-cf299f103b1b"), Code = "NI", Name = "North Island", RegionImageUrl = "https://example.com/north-island.jpg" },
                new Region { Id = new Guid("26031ecb-2754-4431-852f-dce2729a45ec"), Code = "SI", Name = "South Island", RegionImageUrl = "https://example.com/south-island.jpg" },
                new Region { Id = new Guid("495c11c8-1e70-4aa3-805f-2cd85c51050e"), Code = "AU", Name = "Auckland", RegionImageUrl = "https://example.com/auckland.jpg" },
                new Region { Id = new Guid("5b164fea-7e3b-43bd-9582-000d580d5184"), Code = "WK", Name = "Waikato", RegionImageUrl = "https://example.com/waikato.jpg" },
                new Region { Id = new Guid("8006eb7f-ba5a-444d-888c-8436c1ce13d0"), Code = "BP", Name = "Bay of Plenty", RegionImageUrl = "https://example.com/bay-of-plenty.jpg" },
                new Region { Id = new Guid("8053d0ef-a054-4b87-bd16-bd76da7ba654"), Code = "MW", Name = "Manawatu-Whanganui", RegionImageUrl = "https://example.com/manawatu-whanganui.jpg" },
                new Region { Id = new Guid("fed10ff2-47f5-4a6f-b3fb-ed14e3dc655c"), Code = "CA", Name = "Canterbury", RegionImageUrl = "https://example.com/canterbury.jpg" }
            );
        }
    }
}
