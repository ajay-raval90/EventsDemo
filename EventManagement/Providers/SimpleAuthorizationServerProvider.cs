using EventManagement.DB.Entities;
using EventManagement.DB.Repository;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        ProfileRepository _profileRepo;
        public SimpleAuthorizationServerProvider()
        {
            _profileRepo = new ProfileRepository();
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            Profile user = _profileRepo.FindByEmailAndPassword(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            else
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("profileInfo", JsonConvert.SerializeObject(user,new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore})));
                context.Validated(identity);
            }
        }
    }
}