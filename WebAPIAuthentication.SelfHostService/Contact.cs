using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebAPIAuthentication.SelfHostService
{
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

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

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        IList<ApplicationUser>  _users = new List<ApplicationUser>()
        {
            new ApplicationUser(){Id="1", UserName="UserOne", Password = "UserOne"},
            new ApplicationUser(){Id="2", UserName="UserTwo", Password = "UserTwo"}
        };

        public ApplicationUser Find(string _userId, string _password)
        {
            return _users.FirstOrDefault(x => x.Id == _userId && x.Password == _password);
        }
    }
}