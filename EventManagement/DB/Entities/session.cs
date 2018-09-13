using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Entities
{
    public class session
    {
        public int id { get; set; }
        public long eventId { get; set; }
        public string name { get; set; }
        public string presenter { get; set; }
        public string duration{ get; set; }
        public string level { get; set; }
        public string @abstract { get; set; }
        public virtual ICollection<Voter> VoterList{ get; set; }
        [NotMapped]
        public string[] voters { get; set; }
        

    }
}