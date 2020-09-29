using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Web.RazorPages.Data;

namespace PhotoSharingApplication.Web.RazorPages.Pages.PhotosEF
{
    public class EditModel : PageModel
    {
        private readonly PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext _context;

        public EditModel(PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(Photo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PhotoExists(int id)
        {
            return _context.Photo.Any(e => e.Id == id);
        }
    }
}
