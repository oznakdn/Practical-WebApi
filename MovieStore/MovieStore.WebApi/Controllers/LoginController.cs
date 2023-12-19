using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("Login")]
        public IActionResult LoginCustomer(string username,string password)
        {
            
            try
            {
               _customerService.Login(username, password);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);    
            }
            return Ok();
        }

        [HttpGet("Logout")]
        public IActionResult LogoutCustomer(string username, string password)
        {

            try
            {
                _customerService.Logout(username, password);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


    }
}
