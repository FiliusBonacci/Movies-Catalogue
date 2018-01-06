using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace MoviesApp.ViewModels
{
    public class CreateMovieViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Długość nie może być większa niż 100 znaków.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate{ get; set; }

        public int CategoryId { get; set; }
        
        public IQueryable<SelectListItem> Categories { get; set; }
    }
}