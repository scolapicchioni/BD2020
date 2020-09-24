using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Web.RazorPages.Pages.Photos
{
    public class DetailsModel : PageModel
    {
        private readonly IPhotosRepository repository;

        public DetailsModel(IPhotosRepository repository)
        {
            this.repository = repository;
        }
        public Photo Photo { get; set; }
        public void OnGet(int id)
        {
            //get the model
            Photo = repository.GetSinglePhoto(id);
            //return the view with the model in it
        }
    }
}
