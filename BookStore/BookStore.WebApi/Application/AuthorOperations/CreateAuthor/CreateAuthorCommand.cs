using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.AuthorModels;
using System.Linq;
using System;
using BookStore.WebApi.Entities;
using BookStore.WebApi.Validations.AuthorValidators;
using FluentValidation;

namespace BookStore.WebApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public void AddAuthor(CreateAuthorModel model)
        {
            var author=_context.Authors.Where(x=>x.FirstName==model.FirstName && x.LastName==model.LastName).SingleOrDefault();
            if(author is not null) throw new InvalidOperationException("Already there is the author");

            CreateAuthorCommandValidator validator=new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(model);
            author=_mapper.Map<Author>(model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}