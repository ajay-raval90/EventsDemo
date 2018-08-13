using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using EventManagement.DB.Repository;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;

namespace EventManagement
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private IAudienceRepository _audRepo;
        private const string AudiencePropertyKey = "audience";
        private readonly string _issuer = string.Empty;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
            _audRepo = new AudienceRepository();
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            string audienceId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey) ? data.Properties.Dictionary[AudiencePropertyKey] : null;

            if (string.IsNullOrWhiteSpace(audienceId)) throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");

            Audience audience = _audRepo.FindAudience(audienceId);

            string symmetricKeyAsBase64 = audience.Base64Secret;
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);


            //var securityKey = new SymmetricSecurityKey(keyByteArray);
            //var signingCredentials = new SigningCredentials(
            //            securityKey, SecurityAlgorithms.HmacSha256Signature);


            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}