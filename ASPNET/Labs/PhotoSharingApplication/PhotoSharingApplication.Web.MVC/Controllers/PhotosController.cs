﻿using Microsoft.AspNetCore.Mvc;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Upload(Photo photo, IFormFile thePicture)
        {
            //Validation does not check out:
            if (!ModelState.IsValid) {
                //  send the user back to the Update
                //  and show the errors
                return View(photo);
            }
            //validation checks out:
            //  send the photo to the repository
            //  send the user to the AllPhotos action
            photo.DateUploaded = DateTime.Now;

            using MemoryStream memoryStream = new MemoryStream();
            await thePicture.CopyToAsync(memoryStream);
            photo.Picture = memoryStream.ToArray();
            photo.ContentType = thePicture.ContentType;

            repository.AddPhoto(photo);
            return RedirectToAction(nameof(AllPhotos));
        }

        public IActionResult GetImage(int id)
        {
            var photo = repository.GetSinglePhoto(id);
            if (photo == null || photo.Picture == null)
            {
                return NotFound();
            }
            return File(photo.Picture, photo.ContentType);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
