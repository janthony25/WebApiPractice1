using System.ComponentModel.DataAnnotations;

namespace WebApi1.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
