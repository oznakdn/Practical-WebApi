using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.API.Models;
using MyBookStore.API.Repository;

namespace MyBookStore.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }



        [HttpGet]
        public async Task<IActionResult>GetAllBooks()
        {
           var books= await _bookRepository.GetAllBooksAsync();
           return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult>GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult>AddNewBook([FromBody] BookModel bookModel)
        {
            var book = await _bookRepository.AddBookAsync(bookModel);
            return Created("ok", book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateBook([FromBody] BookModel bookModel,[FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult>UpdateBookPatch([FromForm] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeteleBookAsync(id);
            return Ok();
        }

    }
}
