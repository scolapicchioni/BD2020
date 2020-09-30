using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Web.RazorPages.Pages.Photos
{
    public class UploadModel : PageModel
    {
        private readonly IPhotosRepository repository;

        public UploadModel(IPhotosRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Photo Photo { get; set; }

        [BindProperty]
        public IFormFile ThePicture { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() {
            //Validation does not check out:
            if (!ModelState.IsValid)
            {
                //  send the user back to the Update
                //  and show the errors
                return Page();
            }
            //validation checks out:
            //  send the photo to the repository
            //  send the user to the AllPhotos action
            Photo.DateUploaded = DateTime.Now;

            using MemoryStream memoryStream = new MemoryStream();
            await ThePicture.CopyToAsync(memoryStream);
            Photo.Picture = memoryStream.ToArray();
            Photo.ContentType = ThePicture.ContentType;


            repository.AddPhoto(Photo);
            return RedirectToPage("AllPhotos");
            
        }
    }
}
