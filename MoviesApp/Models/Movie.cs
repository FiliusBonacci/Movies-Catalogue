using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate{ get; set; }
        
        public virtual Tag Tag { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}