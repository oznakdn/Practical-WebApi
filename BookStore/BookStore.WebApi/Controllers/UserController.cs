using AutoMapper;
using BookStore.WebApi.Application.UserOperations;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.UserModels;
using BookStore.WebApi.TokenOperations.TokenModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStore.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]s")]
    public class UserController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(BookStoreDbContext context,IMapper mapper, IConfiguration configuration)
        {
            _context=context;
            _mapper=mapper;
            _configuration=configuration;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserModel model)
        {
            CreateUserCommand command=new CreateUserCommand(_context,_mapper);
            command.Model=model;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token>CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model=login;
            var token=command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token>RefreshToken([FromQuery]string token)
        {
            RefreshTokenCommand command=new RefreshTokenCommand(_context,_configuration);
            command.RefreshToken=token;
            var resultToken=command.Handle();
            return resultToken;
        }
    }
}