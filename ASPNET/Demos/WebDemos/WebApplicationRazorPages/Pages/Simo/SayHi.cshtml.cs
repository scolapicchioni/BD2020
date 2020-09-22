using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRazorPages.Models;

namespace WebApplicationRazorPages.Pages.Simo
{
    public class SayHiModel : PageModel
    {
        public Car MyModel_Car { get; set; }
        public void OnGet()
        {
            //retrieve the Model from someone.....
            Car john = new Car() { Id = 1, Brand = "FIAT", Name = "500", Price = 10_000 };
            MyModel_Car = john;
        }
    }
}
