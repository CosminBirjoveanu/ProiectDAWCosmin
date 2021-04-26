using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectDAWCosmin.Models
{
    public class Label
    {
        [Key]
        public int LabelId { get; set; }
        public String Name { get; set; }
    }

}