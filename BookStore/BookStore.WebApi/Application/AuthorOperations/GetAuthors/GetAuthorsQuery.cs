using System.Collections.Generic;
using AutoMapper;
using BookStore.WebApi.DBOperations;
using System.Linq;
using BookStore.WebApi.Models.AuthorModels;

namespace BookStore.WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public List<AuthorsViewModel>GetAllAuthorsModel()
        {
            var authors=_context.Authors.ToList();
            List<AuthorsViewModel> vm=_mapper.Map<List<AuthorsViewModel>>(authors);
            return vm;
        }
    }
}