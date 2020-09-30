using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Models;
using PhotoSharingApplication.Web.RazorPages.Data;

namespace PhotoSharingApplication.Web.RazorPages.Controllers
{
    public class PictureController : Controller
    {
        private readonly PhotoSharingApplicationContext context;
        private readonly IMemoryCache cache;

        public PictureController(PhotoSharingApplicationContext context, IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
        }
        [Route("photos/getimage/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            Photo photo;
            string key = $"Photo-{id}";
            // Look for cache key.
            if (!cache.TryGetValue(key, out photo))
            {
                // Key not in cache, so get data.
                photo = await context.Photo.FirstOrDefaultAsync(m => m.Id == id);
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
            return File(photo.Picture, photo.ContentType);
        }
    }
}
