using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Web.RazorPages.Data;

namespace PhotoSharingApplication.Web.RazorPages.Pages.PhotosEF
{
    public class CreateModel : PageModel
    {
        private readonly PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext _context;

        public CreateModel(PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Photo Photo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Photo.Add(Photo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
