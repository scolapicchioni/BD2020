using System;
using System.Collections.Generic;
using System.Text;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Models;

namespace PhotoSharingApplication.Core.Repositories
{
    public class PhotosRepository : IPhotosRepository
    {
        public List<Photo> GetPhotos()
        {
            return new List<Photo>() {
                new Photo(){Title = "My First Photo!", Description = "Lorem ipsum dolor sit amen" },
                new Photo(){Title = "My Second Photo!", Description = "Bacon ipsum dolor amet filet mignon turducken leberkas ham hock short ribs, tenderloin pastrami pork belly hamburger flank cow. Fatback andouille short ribs, corned beef shoulder pork chop pork shank." },
                new Photo(){Title = "Another Photo", Description = "Swine pork t-bone, kevin doner cow sausage burgdoggen short loin corned beef. Landjaeger pork drumstick sausage. Pig tenderloin frankfurter pastrami turducken boudin turkey." },
                new Photo(){Title = "Yet another photo", Description = "Frankfurter prosciutto doner filet mignon pork. Pig pork belly doner ground round buffalo shankle flank salami fatback ham cupim bresaola chislic pork jowl. Pancetta turkey turducken shankle shoulder pork chop fatback ribeye. Picanha drumstick porchetta ham alcatra buffalo." }
            };
        }
    }
}
