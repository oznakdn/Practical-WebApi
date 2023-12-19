using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.GenreModels;
using BookStore.WebApi.Validations.GenreValidators;
using FluentValidation;
using System;
using System.Linq;
namespace BookStore.WebApi.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public GenreDetailViewModel GetGenreByName(string genreName)
        {
            var genre=_context.Genres.Where(x=>x.IsActive && x.Name==genreName).SingleOrDefault();
            if(genre is null) throw new InvalidOperationException("Genre Not Found");
            
           
            var query=_mapper.Map<GenreDetailViewModel>(genre);
            return query;
        }
    }
}