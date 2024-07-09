using Microsoft.EntityFrameworkCore;
using WebApi1.Data;
using WebApi1.Model;
using WebApi1.Model.Dto;
using WebApi1.Repository.IRepository;

namespace WebApi1.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _dataContext;
        public MovieRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _dataContext.Movies
                .ToListAsync();
        }

        public async Task<List<CategoriesWithMovieDto>> GetCategoriesWithMoviesAsync()
        {
            var categoriesWithMovies = await _dataContext.Categories
                .Include(c => c.MovieCategories)
                    .ThenInclude(mc => mc.Movie)
                .Select(c => new CategoriesWithMovieDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    MovieName = c.MovieCategories.Select(mc => mc.Movie.MovieTitle).ToList()
                }).ToListAsync();

            return categoriesWithMovies;
        }

        public async Task<List<MovieWithCategoriesDto>> GetMovieCategoriesAsync()
        {
            var moviesWithCategories = await _dataContext.Movies
                .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                .Select(m => new MovieWithCategoriesDto
                {
                    MovieId = m.MovieId,
                    MovieTitle = m.MovieTitle,
                    CategoryName = m.MovieCategories.Select(mc => mc.Category.CategoryName).ToList()
                })
                .ToListAsync();


            return moviesWithCategories;

        }
    }
}
