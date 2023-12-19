using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookStore.API.Data;
using MyBookStore.API.Models;

namespace MyBookStore.API.Repository
{
    public class BookRepository:IBookRepository
    {

        private readonly MyBookStoreContext _context;
        private readonly IMapper _mapper;
 
        public BookRepository(MyBookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>>GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);

        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int>AddBookAsync(BookModel bookModel)
        {
            var book = new Book()
            {
                Title=bookModel.Title,
                Description=bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id; 
        }

        public async Task UpdateBookAsync(int bookId,BookModel bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book!=null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;

                await _context.SaveChangesAsync();
            }
        }


        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book!=null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeteleBookAsync(int bookid)
        {
            var book = new Book() { Id = bookid };

            _context.Books.Remove(book);

           await _context.SaveChangesAsync();
         
        }
    }
}
