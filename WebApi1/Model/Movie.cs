using System.ComponentModel.DataAnnotations;

namespace WebApi1.Model
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
