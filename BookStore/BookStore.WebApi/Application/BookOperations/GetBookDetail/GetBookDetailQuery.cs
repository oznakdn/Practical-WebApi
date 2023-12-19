using BookSore.WebApi.Models.BookModels;
using BookStore.WebApi.DBOperations;
using System.Linq;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Application.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public GetBookDetailQuery(int bookId)
        {
            this.BookId = bookId;

        }
        public int BookId { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }


        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x=>x.Genre).Include(x=>x.Author).Where(x => x.Id == BookId).SingleOrDefault();
            if(book==null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }

            BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book);
            //new BookDetailViewModel();
            //vm.Title=book.Title;
            //vm.PageCount=book.PageCount;
            //vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy");
            //vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm;

        }
    }
}