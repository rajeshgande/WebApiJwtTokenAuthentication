using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebAPIAuthentication.SelfHostService
{
    public class UserStore : IUserStore<ApplicationUser>
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}