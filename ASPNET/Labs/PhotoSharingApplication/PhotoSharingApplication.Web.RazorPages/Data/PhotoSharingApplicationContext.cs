using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Web.RazorPages.Data
{
    public class PhotoSharingApplicationContext : DbContext
    {
        public PhotoSharingApplicationContext (DbContextOptions<PhotoSharingApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<PhotoSharingApplication.Core.Models.Photo> Photo { get; set; }

        public DbSet<PhotoSharingApplication.Core.Models.Comment> Comment { get; set; }
    }
}
