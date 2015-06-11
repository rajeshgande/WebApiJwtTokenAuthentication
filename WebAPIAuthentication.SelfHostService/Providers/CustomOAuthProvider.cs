using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace WebAPIAuthentication.SelfHostService.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser applicationUser =  userManager.Find(context.UserName, context.Password);

            if (applicationUser == null)
            {
                context.SetError("invalid_grant", "The ApplicationUser name or password is incorrect.");
                return;
            }
            
            ClaimsIdentity oAuthIdentity = await applicationUser.GenerateUserIdentityAsync(userManager, "JWT");

            oAuthIdentity.AddClaim(new Claim("InstallId", "CPC01"));

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }
}
