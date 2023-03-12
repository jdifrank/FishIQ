using Microsoft.AspNetCore.Mvc;
using WebServerAppDev_Final_Project.Models;

namespace WebServerAppDev_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Fish> fish { get; set; }
        private Repository<Category> categories { get; set; }
        private Repository<Location> locations { get; set; }


        public HomeController(FishContext ctx)
        {
            fish = new Repository<Fish>(ctx);
            categories = new Repository<Category>(ctx);
            locations = new Repository<Location>(ctx);
        }
        public ViewResult Index(int location, int category)
        {
            // options for Locations query
            var locationOptions = new QueryOptions<Location>
            {
                OrderBy = s => s.LocationId
            };

            //options for Category query 
            var categoryOptions = new QueryOptions<Category>
            {
                OrderBy = c => c.CategoryId
            };

            // options for Fish query
            var fishOptions = new QueryOptions<Fish>
            {
                Includes = "Category, Location"
            };
            // order by Locations if no filter. Otherwise, filter by season and order by time.
            if (category != 0)
            {
                fishOptions.Where = c => c.CategoryId == category;
                fishOptions.OrderBy = d => d.Difficulty;
            }
            if (location != 0)
            {
                fishOptions.Where = s => s.LocationId == location;
                fishOptions.OrderBy = d => d.Difficulty;
            }
            else
            {
                fishOptions.OrderBy = c => c.CategoryId;
            }

            // execute queries
            ViewBag.Locations = locations.List(locationOptions);
            ViewBag.Categories = categories.List(categoryOptions);
            return View(fish.List(fishOptions));
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Resources()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Advice()
        {
            return View();
        }
    }
}
