using AutoMapper;
using BookStore.WebApi.Application.GenreOperations.CreateGenre;
using BookStore.WebApi.Application.GenreOperations.DeleteGenre;
using BookStore.WebApi.Application.GenreOperations.GetGenreDetail;
using BookStore.WebApi.Application.GenreOperations.GetGenres;
using BookStore.WebApi.Application.GenreOperations.UpdateGenre;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.GenreModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAllGenre()
        {
            GetGenresQuery genres=new GetGenresQuery(_context,_mapper);
            var result=genres.GetAllGenresModel();
            return Ok(result);
        }

        [HttpGet("GenreName")]
        public IActionResult GetGenreByName(string genreName)
        {
            GetGenreDetailQuery genreDetail=new GetGenreDetailQuery(_context,_mapper);
            var result=genreDetail.GetGenreByName(genreName);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody]CreateGenreModel model)
        {
            CreateGenreCommand createGenre=new CreateGenreCommand(_context,_mapper);
            createGenre.CreateGenre(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGenre(string genreName)
        {
            DeleteGenreCommand deleteGenre=new DeleteGenreCommand(_context);
            deleteGenre.DeleteGenre(genreName);
            return Ok();
        }

        [HttpPut("GenreName")]
        public IActionResult UpdateGenre([FromBody] UpdateGenreModel model, string genreName)
        {
            UpdateGenreCommand updateGenre=new UpdateGenreCommand(_context);
            updateGenre.UpdateGenre(model, genreName);
            return Ok();
        }
    }
}