using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProiectDAWCosmin.Models
{
    [Table("BandWebsite")]
    public class BandWebsite
    {
        [Key]
        public int BandWebsiteId { get; set; }
        public string Website { get; set; }
        public virtual Artist Artist { get; set; }
    }
}