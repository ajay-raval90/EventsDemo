using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Entities
{
    // Events

    public class Event
    {
        public long Id { get; set; } // id (Primary key)
        public string Name { get; set; } // name (length: 500)
        public System.DateTime? Date { get; set; } // date
        public string Time { get; set; } // time (length: 100)
        public int? Price { get; set; } // price
        public string ImageUrl { get; set; } // imageUrl
        public string OnlineUrl { get; set; } // onlineUrl
    }
}