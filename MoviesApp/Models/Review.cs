using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Review : IEntity
    {
        public string Comment { get; set; }
        [Range(0,6 , ErrorMessage ="Wartość musi znajdować się w przedziale [0,6]")]
        public int Grade { get; set; }

        public int MovieId { get; set; }

    }
}