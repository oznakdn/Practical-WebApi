using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.ViewModels.ActorViewModels;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController:ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            var result = _actorService.GetAllActors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActor(int id)
        {
            GetActorModel result;
            try
            {
                result = _actorService.GetActorById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

       [HttpPost]
       public IActionResult AddActor([FromBody] CreateActorModel model)
       {
            try
            {
                _actorService.AddActor(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
       }

        [HttpPut("{id}")]
        public IActionResult UpdateActor([FromBody]UpdateActorModel model, int id)
        {
            try
            {
                _actorService.UpdateActor(model, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            try
            {
                _actorService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
