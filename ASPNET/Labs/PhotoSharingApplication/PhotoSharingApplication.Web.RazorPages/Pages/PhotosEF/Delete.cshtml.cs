using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Web.RazorPages.Data;

namespace PhotoSharingApplication.Web.RazorPages.Pages.PhotosEF
{
    public class DeleteModel : PageModel
    {
        private readonly PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext _context;
        private readonly IAuthorizationService _authorizationService;

        public DeleteModel(PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext context,
            IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
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

            var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, Photo, "DeletePhoto");

            if (authorizationResult.Succeeded)
            {
                if (Photo == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Photo = await _context.Photo.FindAsync(id);
            if (Photo != null)
            {
                var authorizationResult = await _authorizationService
                    .AuthorizeAsync(User, Photo, "DeletePhoto");

                if (authorizationResult.Succeeded)
                {
                    _context.Photo.Remove(Photo);
                    await _context.SaveChangesAsync();
                }
                else if (User.Identity.IsAuthenticated)
                {
                    return new ForbidResult();
                }
                else
                {
                    return new ChallengeResult();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
