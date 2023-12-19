using System;
using System.Collections.Generic;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Entities;
using System.Linq;
using BookStore.WebApi.Models.GenreModels;
using AutoMapper;

namespace BookStore.WebApi.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;
        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public List<Genre>GetAllGenres()
        {
            return _context.Set<Genre>().ToList();
        }

        public List<GenresViewModel>GetAllGenresModel()
        {
            var genres=GetAllGenres().Where(x=>x.IsActive); // true olanları listeler
            List<GenresViewModel>vm=_mapper.Map<List<GenresViewModel>>(genres);
            return vm;
        }
    }
}