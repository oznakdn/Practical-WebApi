using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.AuthorModels;
using System.Linq;
using System;
using BookStore.WebApi.Entities;

namespace BookStore.WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
    
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public void UpdateAuthor(UpdateAuthorModel model, int authorId)
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Id==authorId);
            if(author is null) throw new InvalidOperationException("Not found author for updating");

            
            author.FirstName=model.FirstName!=default ? model.FirstName : author.FirstName;
            author.LastName=model.LastName!=default ? model.LastName : author.LastName;
            author.BirthDate=model.BirthDate!=default ? model.BirthDate : author.BirthDate;
            _context.SaveChanges();
        }
    }
}