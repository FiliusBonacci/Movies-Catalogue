using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Movie : IEntity
    {
        //public int ID { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Długość nie może być większa niż 100 znaków.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate{ get; set; }
        
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}