using EventManagement.Common;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using EventManagement.DB.Repository;
using EventManagement.DB.Entities;

[assembly: OwinStartup(typeof(EventManagement.Startup))]
namespace EventManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:50457"),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()

            };


            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);






            var issuer = "http://localhost:50457";
            AudienceRepository repo = new AudienceRepository();
            List<string> audienceListArray = new List<string>();
            List<IIssuerSecurityTokenProvider> tokenProviders = new List<IIssuerSecurityTokenProvider>();
            List<Audience> audienceList = repo.GetAllAudience();
            foreach (var audience in audienceList)
            {
                audienceListArray.Add(audience.ClientId);
                tokenProviders.Add(new SymmetricKeyIssuerSecurityTokenProvider(issuer, TextEncodings.Base64Url.Decode(audience.Base64Secret)));
            }
            
            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = audienceListArray,
                    IssuerSecurityTokenProviders = tokenProviders
                });

        }

    }
}