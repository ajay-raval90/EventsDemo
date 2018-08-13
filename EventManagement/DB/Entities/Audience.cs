using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.DB.Entities
{
    public class Audience
    {
        [Key]
        [MaxLength(100)]
        public string ClientId { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Base64Secret { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }

    [NotMapped]
    public class AudienceModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}