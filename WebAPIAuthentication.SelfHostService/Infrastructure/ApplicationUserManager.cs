using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace WebAPIAuthentication.SelfHostService
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        IList<ApplicationUser>  _users = new List<ApplicationUser>()
        {
            new ApplicationUser(){Id="1", UserName="UserOne", Password = "UserOne"},
            new ApplicationUser(){Id="2", UserName="UserTwo", Password = "UserTwo"}
        };

        public static ApplicationUserManager Create()
        {
            return new ApplicationUserManager(new UserStore());
        }

       
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public ApplicationUser Find(string _userId, string _password)
        {
            return _users.FirstOrDefault(x => x.UserName == _userId && x.Password == _password);
        }
    }
}