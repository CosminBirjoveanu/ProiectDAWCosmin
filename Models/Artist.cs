using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAWCosmin.Models
{
    public class Artist
    { 
        [Key]
        public int ArtistId { get; set; }
        [MaxLength(200, ErrorMessage = "Name too long!")]
        public string Name { get; set; }
        [Required]
        public virtual BandWebsite BandWebsite { get; set; }
    }
}