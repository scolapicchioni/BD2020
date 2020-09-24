using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoSharingApplication.Web.RazorPages.Models;
using PhotoSharingApplication.Web.RazorPages.Repositories;

namespace PhotoSharingApplication.Web.RazorPages.Pages.Photos
{
    public class AllPhotosModel : PageModel
    {
        public List<Photo> Photos { get; set; }
        public void OnGet()
        {
            //get the model
            PhotosRepository repository = new PhotosRepository();
            List<Photo> photos = repository.GetPhotos();
            //return the view with the model in it
            Photos = photos;
        }
    }
}
