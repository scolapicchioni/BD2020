using Microsoft.AspNetCore.Authorization;
using PhotoSharingApplication.Core.Models;
using System.Threading.Tasks;

namespace PhotoSharingApplication.Web.RazorPages.Authorization
{
    public class UserOwnsPhotoAuthorizationHandler :
    AuthorizationHandler<UserOwnsPhotoRequirement, Photo>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       UserOwnsPhotoRequirement requirement,
                                                       Photo photo)
        {
            if (context.User.Identity?.Name == photo?.UserName)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
