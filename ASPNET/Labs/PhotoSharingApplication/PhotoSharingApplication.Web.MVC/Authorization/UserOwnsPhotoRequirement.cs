using Microsoft.AspNetCore.Authorization;

namespace PhotoSharingApplication.Web.MVC.Authorization
{
    public class UserOwnsPhotoRequirement : IAuthorizationRequirement
    {
    }
}
