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

        //photos/upload GET
        [HttpGet]
        public IActionResult Upload() {
            return View();
        }

        //photos/upload POST
        [HttpPost]
        public IActionResult Upload(Photo photo)
        {
            //if validation checks out:
            //  send the photo to the repository
            //  send the user to the AllPhotos action
            //otherwise:
            //  send the user back to the Update
            //  and show the errors
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
