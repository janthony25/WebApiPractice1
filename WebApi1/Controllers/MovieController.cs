using Microsoft.AspNetCore.Mvc;
using WebApi1.Data;
using WebApi1.Repository;
using WebApi1.Repository.IRepository;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly DataContext _context;
        private readonly IMovieRepository _movieRepository;
        public MovieController(DataContext context, IMovieRepository movieRepository)
        {
            _context = context;
            _movieRepository = movieRepository;
        }

        [HttpGet("movies")]
        public async Task<ActionResult> GetAllMovies()
        {
            var movieList = await _movieRepository.GetAllMoviesAsync();
            return Ok(movieList);
        }

        [HttpGet("movieWithCategory")]
        public async Task<IActionResult> GetMovieWithCategory()
        {
            var movieWIthCategories = await _movieRepository.GetMovieCategoriesAsync();
            return Ok(movieWIthCategories);
        }

        [HttpGet("categories")]
        public IActionResult GetAllCategories() 
        {
            var categoryList = _context.Categories.ToList();
            return Ok(categoryList);
        }

        [HttpGet("categoriesWithMovies")]
        public async Task<IActionResult> GetCategoriesWIthMovie()
        {
            var categoriesWithMovie = await _movieRepository.GetCategoriesWithMoviesAsync();
            return Ok(categoriesWithMovie);
        }
    }
}
