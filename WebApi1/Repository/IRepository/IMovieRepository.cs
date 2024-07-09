using WebApi1.Model;
using WebApi1.Model.Dto;

namespace WebApi1.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<List<MovieWithCategoriesDto>> GetMovieCategoriesAsync();
        Task<List<CategoriesWithMovieDto>> GetCategoriesWithMoviesAsync();
    }
}
