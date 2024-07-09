namespace WebApi1.Model.Dto
{
    public class MovieWithCategoriesDto
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public List<String> CategoryName { get; set; }
    }
}
