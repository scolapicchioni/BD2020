using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Web.RazorPages.Pages.Photos
{
    public class AllPhotosModel : PageModel
    {
        private readonly IPhotosRepository repository;

        public AllPhotosModel(IPhotosRepository repository)
        {
            this.repository = repository;
        }
        public List<Photo> Photos { get; set; }
        public void OnGet()
        {
            //get the model
            List<Photo> photos = repository.GetPhotos();
            //return the view with the model in it
            Photos = photos;
        }
    }
}
