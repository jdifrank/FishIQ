using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebServerAppDev_Final_Project.Models
{
    internal class FishConfig : IEntityTypeConfiguration<Fish>
    {
        public void Configure(EntityTypeBuilder<Fish> entity)
        {
            //Delete behavior for Category foreign key set to Restrict 
            entity.HasOne(r => r.Category)
                .WithMany(c => c.Fish)
                .OnDelete(DeleteBehavior.Restrict);

            //Delete behavior for Location foreign key set to Restrict 
            entity.HasOne(r => r.Location)
                .WithMany(s => s.Fish)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Fish { FishId = 1, Name = "Largemouth Bass",  Difficulty = 2, CategoryId = 2, LocationId = 1 },
                new Fish { FishId = 2, Name = "Smallmouth Bass",  Difficulty = 2, CategoryId = 2, LocationId = 2 },
                new Fish { FishId = 4, Name = "Sunfish",  Difficulty = 1, CategoryId = 1, LocationId = 1 },
                new Fish { FishId = 5, Name = "Crappie", Difficulty = 1, CategoryId = 1, LocationId = 1 },
                new Fish { FishId = 6, Name = "Sucker",  Difficulty = 1, CategoryId = 3, LocationId = 3 },
                new Fish { FishId = 7, Name = "Lake Sturgeon",  Difficulty = 4, CategoryId = 3, LocationId = 2 },
                new Fish { FishId = 8, Name = "Channel Catfish", Difficulty = 2, CategoryId = 4, LocationId = 2 },
                new Fish { FishId = 9, Name = "Steelhead Trout",  Difficulty = 4, CategoryId = 5, LocationId = 4 },
                new Fish { FishId = 10, Name = "Sheephead",  Difficulty = 2, CategoryId = 8, LocationId = 2 }
               

             );
        }
    }
}
