using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoSharingApplication.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int PhotoId { get; set; }
    }
}
