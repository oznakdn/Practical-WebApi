using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.GenreModels;
using System.Linq;
using System;

namespace BookStore.WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context=context;
        }

        public void UpdateGenre(UpdateGenreModel model, string genreName)
        {
            var updateGenre=_context.Genres.SingleOrDefault(x=>x.Name==genreName);
            if(updateGenre is null) throw new InvalidOperationException($"Not found {model.Name} for deleting");

            updateGenre.Name=string.IsNullOrEmpty(model.Name) ? updateGenre.Name : model.Name;
            updateGenre.IsActive=model.IsActive;

            _context.SaveChanges();
        }
    }
}