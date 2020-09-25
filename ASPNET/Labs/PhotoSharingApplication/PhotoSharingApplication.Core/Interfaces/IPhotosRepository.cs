using PhotoSharingApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoSharingApplication.Core.Interfaces
{
    public interface IPhotosRepository
    {
        void AddPhoto(Photo photo);
        List<Photo> GetPhotos();
        Photo GetSinglePhoto(int id);
    }
}
