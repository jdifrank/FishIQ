using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServerAppDev_Final_Project.Models
{
    public class Location
    {
        public int LocationId { get; set; }  //PK

        [StringLength(100, ErrorMessage = "Location name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a Location name.")]
        public string Name { get; set; }
        public ICollection<Fish> Fish { get; set; } //Navigation property
    }
}
