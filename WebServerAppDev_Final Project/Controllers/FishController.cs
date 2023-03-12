using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServerAppDev_Final_Project.Models;

namespace WebServerAppDev_Final_Project.Controllers
{
    public class FishController : Controller
    {
        private Repository<Fish> fish { get; set; }
        private Repository<Category> categories { get; set; }
        private Repository<Location> locations { get; set; }

        public FishController(FishContext ctx)
        {
            fish = new Repository<Fish>(ctx);
            categories = new Repository<Category>(ctx);
            locations = new Repository<Location>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var r = this.GetFish(id);
            return View("Add", r);

        }

        [HttpPost]
        public IActionResult Add(Fish r)
        {
            if (ModelState.IsValid)
            {
                if (r.FishId == 0)
                    fish.Insert(r);
                else
                    fish.Update(r);
                fish.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (r.FishId == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var opr = this.GetFish(id);
            return View(opr);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Fish r)
        {
            fish.Delete(r);
            fish.Save();
            return RedirectToAction("Index", "Home");
        }


        // private helper methods
        private Fish GetFish(int id)
        {
            var fishOptions = new QueryOptions<Fish>
            {
                Includes = "Category, Location",
                Where = r => r.FishId == id
            };
            var list = fish.List(fishOptions);

            // return first Class or blank Class if null
            return list.FirstOrDefault();
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Categories = categories.List(new QueryOptions<Category>
            {
                OrderBy = c => c.CategoryId
            });
            ViewBag.Locations = locations.List(new QueryOptions<Location>
            {
                OrderBy = s => s.LocationId
            });
            ViewBag.Operation = operation;
        }
    }
}
