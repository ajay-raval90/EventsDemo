using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using EventManagement.DB.Repository;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IAudienceRepository _audRepo;
        private IProfileRepository _profRepo;
        public CustomOAuthProvider()
        {
            _audRepo = new AudienceRepository();
            _profRepo = new ProfileRepository();
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }

            var audience = _audRepo.FindAudience(context.ClientId);

            if (audience == null)
            {
                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            Profile prof = _profRepo.FindByEmailAndPassword(context.UserName, context.Password);
            if (prof == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Supervisor"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", (context.ClientId == null) ? string.Empty : context.ClientId
                    },
                    {
                        "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                    },
                    {
                        "userName", context.UserName
                    }
                });


            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}