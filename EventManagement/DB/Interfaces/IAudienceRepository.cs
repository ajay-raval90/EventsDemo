using EventManagement.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Interfaces
{
    public interface IAudienceRepository
    {
        Audience AddAudience(string name);
        Audience FindAudience(string clientId);
        void SeedAudience();
    }
}