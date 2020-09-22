using Microsoft.AspNetCore.Mvc;
using PhotoSharingApplication.Web.MVC.Models;
using PhotoSharingApplication.Web.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSharingApplication.Web.MVC.Controllers
{
    public class PhotosController : Controller
    {
        //Photos/AllPhotos
        public IActionResult AllPhotos() {
            //get the model
            PhotosRepository repository = new PhotosRepository();
            List<Photo> photos = repository.GetPhotos();
            //return the view with the model in it
            return View(photos);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
