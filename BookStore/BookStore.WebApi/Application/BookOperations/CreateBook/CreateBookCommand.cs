using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.BookModels;
using System.Linq;
using System;
using AutoMapper;
using BookStore.WebApi.Entities;

namespace BookStore.WebApi.Application.BookOperations.GetBooks.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model{get;set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public void Handle()
        {
            var book=_context.Books.SingleOrDefault(x=>x.Title==Model.Title);
            if(book!=null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            // Model ile gelen veriyi Book objesine çevir (içerisine mapple)
            book=_mapper.Map<Book>(Model);
            //book= new Book();
            //book.Title=Model.Title;
            //book.PublishDate=Model.PublishDate;
            //book.PageCount=Model.PageCount;
            //book.GenreId=Model.GenreId;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        
    }
}