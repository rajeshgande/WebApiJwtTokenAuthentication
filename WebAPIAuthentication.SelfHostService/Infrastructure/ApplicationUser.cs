using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebAPIAuthentication.SelfHostService
{
    public class ApplicationUser : Microsoft.AspNet.Identity.IUser<string>
    {
        public IList<Claim> Claims { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here

            return userIdentity;
        }
    }
}