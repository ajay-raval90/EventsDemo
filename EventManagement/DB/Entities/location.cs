using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Entities
{
    public class location
    {
        [Key]
        public int id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}