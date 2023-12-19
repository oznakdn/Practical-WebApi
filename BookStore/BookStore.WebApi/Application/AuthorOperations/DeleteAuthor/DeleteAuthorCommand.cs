using BookStore.WebApi.DBOperations;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context=context;
        }

        public void DeleteAuthor(int authorId)
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Id==authorId);
            if(author is null) throw new InvalidOperationException("Not found deleting author");


            /* Kitaplar içerisinde AuthorId ile metot parametresindeki authorId yi eşleştirdik.Bu durum sağlanırsa
               yani kitanın bir yazarı varsa yazar silinemez ve öncelikle ilgili kitabın silinmesi gerekir.
               Bu koşulun sağlanması durumunu if içerisindeki Any() metoduyla yaptık.Any() metodu, authorBook'un sağlandığı-gerçekleştiği
               durumun atandığı değişkendir.
            */
            var authorsBook=_context.Books.Where(x=>x.AuthorId==authorId);
            if(authorsBook.Any()) throw new InvalidOperationException("Not deleting! Author has a book");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}