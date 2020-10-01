using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Web.MVC.Data;

namespace PhotoSharingApplication.Web.MVC.Controllers
{
    public class PhotosEFController : Controller
    {
        private readonly PhotoSharingApplicationContext _context;
        private readonly IMemoryCache cache;
        private readonly IAuthorizationService authorizationService;

        public PhotosEFController(PhotoSharingApplicationContext context, 
            IMemoryCache cache,
            IAuthorizationService authorizationService)
        {
            _context = context;
            this.cache = cache;
            this.authorizationService = authorizationService;
        }

        // GET: PhotosEF
        public async Task<IActionResult> Index()
        {
            return View(await _context.Photo.OrderByDescending(p=>p.DateUploaded).ToListAsync());
        }

        // GET: PhotosEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Photo photo;
            string key = $"Photo-{id}";
            // Look for cache key.
            if (!cache.TryGetValue(key, out photo))
            {
                // Key not in cache, so get data.
                photo = await _context.Photo.FirstOrDefaultAsync(m => m.Id == id);
                if (photo == null)
                {
                    return NotFound();
                }

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                // Save data in cache.
                cache.Set(key, photo, cacheEntryOptions);
            }

            return View(photo);
        }

        [Authorize]
        // GET: PhotosEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhotosEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Photo photo, IFormFile thePicture)
        {
            
            if (ModelState.IsValid)
            {
                photo.UserName = User.Identity.Name;

                photo.DateUploaded = DateTime.Now;

                using MemoryStream memoryStream = new MemoryStream();
                await thePicture.CopyToAsync(memoryStream);
                photo.Picture = memoryStream.ToArray();
                photo.ContentType = thePicture.ContentType;

                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        public async Task<IActionResult> GetImage(int id) {
            var photo = await _context.Photo.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return File(photo.Picture,photo.ContentType);
        }

        // GET: PhotosEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: PhotosEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Photo photo)
        {
            if (id != photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        [Authorize]
        // GET: PhotosEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo
                .FirstOrDefaultAsync(m => m.Id == id);

            var authorizationResult = await authorizationService
            .AuthorizeAsync(User, photo, "PhotoDeletePolicy");

            if (authorizationResult.Succeeded)
            {
                if (photo == null)
                {
                    return NotFound();
                }

                return View(photo);
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

        // POST: PhotosEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo = await _context.Photo.FindAsync(id);

            var authorizationResult = await authorizationService
            .AuthorizeAsync(User, photo, "PhotoDeletePolicy");

            if (authorizationResult.Succeeded)
            {
                _context.Photo.Remove(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

        private bool PhotoExists(int id)
        {
            return _context.Photo.Any(e => e.Id == id);
        }
    }
}
