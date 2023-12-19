using AutoMapper;
using BookStore.WebApi.DBOperations;
using System.Linq;
using System;
using BookStore.WebApi.Models.AuthorModels;

namespace BookStore.WebApi.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public AuthorDetailViewModel GetAuthorById(int id)
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Id==id);
            if(author is null) throw new InvalidOperationException("Not found author");

            AuthorDetailViewModel vm=_mapper.Map<AuthorDetailViewModel>(author);
            return vm;

        }
    }
}