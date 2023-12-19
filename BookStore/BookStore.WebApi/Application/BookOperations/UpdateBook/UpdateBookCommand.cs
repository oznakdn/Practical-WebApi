using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.BookModels;
using System.Linq;
using System;

namespace BookStore.WebApi.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        public UpdateBookModel Model {get;set;}
        private readonly BookStoreDbContext _context;
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context=context;
        }

        public void Handle()
        {
            var book=_context.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
            {
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı!");
            }

            book.Title=Model.Title!=default ? Model.Title : book.Title;
            book.GenreId=Model.GenreId!=default ? Model.GenreId : book.GenreId;
            book.AuthorId=Model.AuthorId!=default ? Model.AuthorId : book.AuthorId;
            _context.SaveChanges();
        }
    }
}