using EventManagement.DB;
using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace EventManagement.DB.Repository
{
    public class AudienceRepository : IDisposable, IAudienceRepository
    {
        private EventDbContext context;
        public AudienceRepository(EventDbContext context)
        {
            this.context = context;
        }
        public AudienceRepository()
        {
            this.context = new EventDbContext();
        }
        public Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            Audience newAudience = new Audience { ClientId = clientId, Base64Secret = base64Secret, Name = name };
            context.Audience.Add(newAudience);
            context.SaveChanges();
            return newAudience;
        }

        public Audience FindAudience(string clientId)
        {
            return context.Audience.Find(clientId);
        }
        public void SeedAudience()
        {
            if (context.Audience.Count() == 0)
            {
                AddAudience("EventManagement.Api 1");
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}