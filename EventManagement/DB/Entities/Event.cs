using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Entities
{
    // Events

    public class Event
    {
        public long id { get; set; } // id (Primary key)
        public string name{ get; set; } // name (length: 500)
        public DateTime date{ get; set; } // date
        public string time { get; set; } // time (length: 100)
        public decimal? price { get; set; } // price
        public string imageUrl { get; set; } // imageUrl
        public string onlineUrl { get; set; } // onlineUrl
        [ForeignKey("location")]
        public int? locationId { get; set; }
        public virtual location location { get; set; }
        public virtual ICollection<session> sessions { get; set; }
    }
}