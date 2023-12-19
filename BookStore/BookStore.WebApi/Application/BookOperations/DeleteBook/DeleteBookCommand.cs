using BookStore.WebApi.DBOperations;
using System.Linq;
using System;

namespace BookStore.WebApi.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId{get;set;}
        private readonly BookStoreDbContext _context;
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context=context;
        }

        public void Handle()
        {
            var book=_context.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
            {
                throw new InvalidOperationException("Silmek İstediğiniz Kitap Bulunamadı!");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}