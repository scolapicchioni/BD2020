using Microsoft.AspNetCore.Mvc;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSharingApplication.Web.MVC.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotosRepository repository;

        public PhotosController(IPhotosRepository repository)
        {
            this.repository = repository;
        }
        //Photos/AllPhotos
        public IActionResult AllPhotos() {
            //get the model
            List<Photo> photos = repository.GetPhotos();
            //return the view with the model in it
            return View(photos);
        }

        //Photos/Details/5
        public IActionResult Details(int id)
        {
            //get the model
            Photo photo = repository.GetSinglePhoto(id);
            //return the view with the model in it
            return View(photo);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
