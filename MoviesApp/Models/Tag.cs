using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Tag : IEntity
    {
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}