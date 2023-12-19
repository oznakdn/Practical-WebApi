using AutoMapper;
using BookStore.WebApi.Application.AuthorOperations.CreateAuthor;
using BookStore.WebApi.Application.AuthorOperations.DeleteAuthor;
using BookStore.WebApi.Application.AuthorOperations.GetAuthorDetail;
using BookStore.WebApi.Application.AuthorOperations.GetAuthors;
using BookStore.WebApi.Application.AuthorOperations.UpdateAuthor;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.AuthorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController:ControllerBase
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            GetAuthorsQuery authors= new GetAuthorsQuery(_context,_mapper);
            var result=authors.GetAllAuthorsModel();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetAuthorDetailQuery author=new GetAuthorDetailQuery(_context,_mapper);
            var result=author.GetAuthorById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody]CreateAuthorModel model)
        {
            CreateAuthorCommand author=new CreateAuthorCommand(_context,_mapper);
            author.AddAuthor(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAuthor([FromBody]UpdateAuthorModel model, int AuthorId)
        {
            UpdateAuthorCommand author=new UpdateAuthorCommand(_context,_mapper);
            author.UpdateAuthor(model,AuthorId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand author=new DeleteAuthorCommand(_context);
            author.DeleteAuthor(id);
            return Ok();
        }
    }
}