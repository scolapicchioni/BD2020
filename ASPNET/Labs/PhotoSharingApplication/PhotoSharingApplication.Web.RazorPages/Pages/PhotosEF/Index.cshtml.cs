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
    public class IndexModel : PageModel
    {
        private readonly PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext _context;

        public IndexModel(PhotoSharingApplication.Web.RazorPages.Data.PhotoSharingApplicationContext context)
        {
            _context = context;
        }

        public IList<Photo> Photo { get;set; }

        public async Task OnGetAsync()
        {
            Photo = await _context.Photo.ToListAsync();
        }
    }
}
