using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Web.RazorPages.Data;

namespace PhotoSharingApplication.Web.RazorPages.Pages.PhotosEF
{
    public class DetailsModel : PageModel
    {
        private readonly PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext _context;

        public DetailsModel(PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext context)
        {
            _context = context;
        }

        public Photo Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Photo = await _context.Photo.FirstOrDefaultAsync(m => m.Id == id);

            if (Photo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
