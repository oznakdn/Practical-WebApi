using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.GenreModels;
using System.Linq;
using System;
using BookStore.WebApi.Entities;
using BookStore.WebApi.Validations.GenreValidators;
using FluentValidation;

namespace BookStore.WebApi.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public void CreateGenre(CreateGenreModel model)
        {
           var genre=_context.Genres.Where(x=>x.Name==model.Name).SingleOrDefault();
           if(genre is not null) throw new InvalidOperationException("Just there is this genre");
           
           CreateGenreValidator validator=new CreateGenreValidator();
           validator.ValidateAndThrow(model);

           var result=_mapper.Map<Genre>(model);
           _context.Add(result);
           _context.SaveChanges();

        }
    }
}