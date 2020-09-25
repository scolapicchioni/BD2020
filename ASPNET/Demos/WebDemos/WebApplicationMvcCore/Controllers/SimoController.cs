using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMvcCore.Models;

namespace WebApplicationMvcCore.Controllers
{
    public class SimoController : Controller
    {
        public SimoController()
        {

        }
        public IActionResult SayHi()
        {
            //retrieve the Model from someone.....
            Car john = new Car() { Id = 1, Brand = "FIAT", Name = "500", Price = 10_000 };
            //return Content("<html><head></head><body></body></html>");
            return View(john);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid) {
                return View(car);
            }
            //add the car to the db

            return RedirectToAction(nameof(SayHi));
        }


        //mysite/simo/GetCarByBrand?brand=fiat
        //mysite/cars/brand/fiat
        [Route("/cars/brand/{brand}")]
        [Route("/cars-by-brand/{brand}")]
        public IActionResult GetCarByBrand(string brand) {
            return View(new List<Car>() { new Car() { Brand = brand } }); 
        }
    }
}
