using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.DB.Entities
{
    public class Voter
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("session")]
        public int sessionId { get; set; }
        [ForeignKey("profile")]
        public long ProfileId { get; set; }
        public virtual session session { get; set; }
        public virtual Profile profile { get; set; }
    }
}