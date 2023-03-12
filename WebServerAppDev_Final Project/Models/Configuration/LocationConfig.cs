using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebServerAppDev_Final_Project.Models
{
    internal class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.HasData(
                new Location { LocationId = 1, Name = "Pond" },
                new Location { LocationId = 2, Name = "Lake" },
                new Location { LocationId = 3, Name = "River" },
                new Location { LocationId = 4, Name = "Stream" },
                new Location { LocationId = 5, Name = "Ocean" }
            );
        }
    }
}
