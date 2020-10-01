using Microsoft.AspNetCore.Authorization;

namespace PhotoSharingApplication.Web.RazorPages.Authorization
{
    public class UserOwnsPhotoRequirement : IAuthorizationRequirement
    {
    }
}
