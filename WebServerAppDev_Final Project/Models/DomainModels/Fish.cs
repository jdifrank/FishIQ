using System;
using System.ComponentModel.DataAnnotations;

namespace WebServerAppDev_Final_Project.Models
{
    public class Fish 
    {
        //EF Core will configure the database to generate this value
        public int FishId { get; set; }  //Primary Key 

        [StringLength(200, ErrorMessage = "Name may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a fish name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a difficulty for catching fish.")]
        [Range(1, 5, ErrorMessage =
            "Difficulty of catching fish must be between 1 and 5.")]
        public int? Difficulty { get; set; }


        public int CategoryId { get; set; } //Foreign key property 
        public Category Category { get; set; } //Navigation property 

        //Make nullable - int?SeasonId
        public int LocationId { get; set; } //Foreign key property 
        public Location Location { get; set; } //Navigation property 
    }
}
