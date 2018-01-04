namespace MoviesApp.Models
{
    public class Review : IEntity
    {
        public string Comment { get; set; }
        public int Grade { get; set; }

        public virtual Movie Movie { get; set; }

    }
}