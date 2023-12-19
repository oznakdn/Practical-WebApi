using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;

namespace MovieStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var result = _movieService.GetAllMovieWithActors();
            return Ok(result);
        }

        [HttpGet("MovieTitle")]
        public IActionResult GetMovieByTitle(string Title)
        {
            GetAllMoviesModel result;
            try
            {
                result = _movieService.GetMovieByTitle(Title);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);


        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel model)
        {
            try
            {
                _movieService.AddMovie(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
           
        }

        [HttpPut("MovieTitle")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieModel model, string MovieTitle)
        {

            try
            {
                _movieService.UpdateMovie(model, MovieTitle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
            
            
        }

        [HttpDelete]
        public IActionResult DeleteMovie(string Title)
        {
            try
            {
                _movieService.SoftDelete(Title);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


       
    }
}
