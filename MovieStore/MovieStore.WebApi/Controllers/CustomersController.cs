using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController:ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel model)
        {
            try
            {
                _customerService.AddCustomer(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("Username-Password")]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerModel model,string username,string password)
        {
            try
            {
                _customerService.UpdateCustomer(model, username, password);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomer();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _customerService.SoftDelete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet("CustomerWithFavoriteGenres")]
        public IActionResult GetAllCustomerWithFavorites()
        {
           var result= _customerService.GetAllCustomersWithFavoriteGenres();
            return Ok(result);
        }
       
    }
}
