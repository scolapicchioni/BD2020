using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoSharingApplication.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateUploaded { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
