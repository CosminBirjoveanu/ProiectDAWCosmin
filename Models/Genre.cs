using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAWCosmin.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Album> albums { get; set; }
    }
}