using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.BookModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.WebApi.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public List<BooksViewModel>Handle()
        {
            var bookList=_context.Books.Include(x=>x.Genre).Include(x=>x.Author).ToList();
            List<BooksViewModel>vm=_mapper.Map<List<BooksViewModel>>(bookList);
            /*
            new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel(){
                    Title=book.Title,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount=book.PageCount
                });
            }
            */
            return vm;
        }
    }
}