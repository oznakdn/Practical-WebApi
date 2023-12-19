using BookStore.WebApi.DBOperations;
using System.Linq;
using System;
using BookStore.WebApi.Entities;
using BookStore.WebApi.Validations.GenreValidators;
using FluentValidation;
using BookStore.WebApi.Models.GenreModels;

namespace BookStore.WebApi.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {

        private readonly BookStoreDbContext _context;
        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context=context;
        }

        // Soft Delete
        public void DeleteGenre(string genreName)
        {
            var genre=_context.Genres.SingleOrDefault(x=>x.Name==genreName);
            if(genre is null) throw new InvalidOperationException("Not Found This Genre");

            genre.IsActive=false;
           _context.SaveChanges();

        }
    }
}