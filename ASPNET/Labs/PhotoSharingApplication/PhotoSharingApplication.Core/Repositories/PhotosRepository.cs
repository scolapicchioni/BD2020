using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Core.Repositories
{
    public class PhotosRepository : IPhotosRepository {
        private List<Photo> db;
        public PhotosRepository() {
            db = new List<Photo>() {
                new Photo() { Id = 1, Title = "My First Photo!", Description = "Lorem ipsum dolor sit amen" },
                new Photo() { Id = 2, Title = "My Second Photo!", Description = "Bacon ipsum dolor amet filet mignon turducken leberkas ham hock short ribs, tenderloin pastrami pork belly hamburger flank cow. Fatback andouille short ribs, corned beef shoulder pork chop pork shank." },
                new Photo() { Id = 3, Title = "Another Photo", Description = "Swine pork t-bone, kevin doner cow sausage burgdoggen short loin corned beef. Landjaeger pork drumstick sausage. Pig tenderloin frankfurter pastrami turducken boudin turkey." },
                new Photo() { Id = 4, Title = "Yet another photo", Description = "Frankfurter prosciutto doner filet mignon pork. Pig pork belly doner ground round buffalo shankle flank salami fatback ham cupim bresaola chislic pork jowl. Pancetta turkey turducken shankle shoulder pork chop fatback ribeye. Picanha drumstick porchetta ham alcatra buffalo." }
            };
        }
        public List<Photo> GetPhotos() {
            return db;
        }
        public Photo GetSinglePhoto(int id) {
            return db.FirstOrDefault(p => p.Id == id); //null
        }

        public void AddPhoto(Photo photo)
        {
            photo.Id = db.Max(p => p.Id) + 1;
            db.Add(photo);
        }
    }
}
