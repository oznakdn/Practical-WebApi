using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.ViewModels.FavoriteGenresModels;

namespace MovieStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteGenresController : ControllerBase
    {
        private readonly IFavoriteGenreService _favoriteGenreService;
        public FavoriteGenresController(IFavoriteGenreService favoriteGenreService)
        {
            _favoriteGenreService = favoriteGenreService;
        }

        [HttpPost]
        public IActionResult AddFavoriteGenre([FromBody] CreateFavoriteGenresModel model)
        {
            try
            {
                _favoriteGenreService.AddFavoriteGenre(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
