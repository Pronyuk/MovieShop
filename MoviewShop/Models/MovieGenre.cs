using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviewShop.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
    }
}