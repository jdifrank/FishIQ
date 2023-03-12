using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebServerAppDev_Final_Project.Models 
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { CategoryId = 1, Name = "Pan Fish" },
                new Category { CategoryId = 2, Name = "Bass" },
                new Category { CategoryId = 3, Name = "Sucker Fish" },
                new Category { CategoryId = 4, Name = "Catfish" },
                new Category { CategoryId = 5, Name = "Trout" },
                new Category { CategoryId = 6, Name = "Pike" },
                new Category { CategoryId = 7, Name = "Salmon" },
                new Category { CategoryId = 8, Name = "Drum" },
                new Category { CategoryId = 9, Name = "Saltwater" }
                );
        }

    }
}
