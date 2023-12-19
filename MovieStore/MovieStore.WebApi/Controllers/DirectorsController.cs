using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.ViewModels.DirectorViewModels;

namespace MovieStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public IActionResult GetAllDirectors()
        {
            var result = _directorService.GetAllDirectors();
            return Ok(result);
        }

        [HttpGet("FirsName&LastName")]
        public IActionResult GetDirector(string firstName,string lastName)
        {
            GetDirectorModel result;
            try
            {
               result=_directorService.GetDirectorByFullName(firstName, lastName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel model)
        {
            try
            {
                _directorService.AddDirector(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector([FromBody]UpdateDirectorModel model ,int id)
        {
            try
            {
                _directorService.UpdateDirector(model, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                _directorService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
