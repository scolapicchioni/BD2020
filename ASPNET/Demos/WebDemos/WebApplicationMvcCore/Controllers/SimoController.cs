using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMvcCore.Models;

namespace WebApplicationMvcCore.Controllers
{
    public class SimoController : Controller
    {
        private ILogger<SimoController> _logger;
        private readonly IMemoryCache _cache;

        public SimoController(ILogger<SimoController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }
        public IActionResult SayHi()
        {
            _logger.LogWarning("SAY HI has been called!!");
            //retrieve the Model from someone.....
            Car john = new Car() { Id = 1, Brand = "FIAT", Name = "500", Price = 10_000 };
            //return Content("<html><head></head><body></body></html>");
            return View(john);
        }

        [Route("/cars/id/{id}")]
        public IActionResult GetCarById(int id)
        {
            Car cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue("Car" + id, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = new Car() { Id = id, Brand = "FIAT", Name = "500", Price = 10_000 }; ;

                // Set cache options.
                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //    // Keep in cache for this time, reset time if accessed.
                //    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Save data in cache.
                _cache.Set("Car"+ id, cacheEntry);
            }

            return View(cacheEntry);
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

        public IActionResult SignalRDemo()
        {
            return View();
        }
    }
}
