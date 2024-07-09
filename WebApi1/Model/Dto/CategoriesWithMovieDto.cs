namespace WebApi1.Model.Dto
{
    public class CategoriesWithMovieDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<String> MovieName { get; set; }
    }
}
