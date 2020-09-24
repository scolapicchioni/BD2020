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
    }
}
