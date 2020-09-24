using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Web.RazorPages.Pages.Photos
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public Photo Photo { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            //if validation checks out:
            //  send the photo to the repository
            //  send the user to the AllPhotos action
            //otherwise:
            //  send the user back to the Update
            //  and show the errors
            return Page();
        }
    }
}
