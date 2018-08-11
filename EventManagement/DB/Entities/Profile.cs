using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Entities
{
    

    // Profiles
    
    public class Profile
    {
        public long Id { get; set; } // Id (Primary key)
        public string FirstName { get; set; } // FirstName (length: 500)
        public string LastName { get; set; } // LastName (length: 500)
        public string UserName { get; set; } // UserName (length: 500)
        public string Email { get; set; } // Email (length: 1000)
        public string Password { get; set; } // Password
        public string Salt { get; set; } // Salt
        public System.DateTime CreatedAt { get; set; } // CreatedAt
        public System.DateTime? UpdatedAt { get; set; } // UpdatedAt
    }

}