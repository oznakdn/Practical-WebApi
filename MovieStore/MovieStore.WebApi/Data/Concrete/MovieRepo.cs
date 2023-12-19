using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.Enums;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;

namespace MovieStore.WebApi.Data.Concrete
{
    public class MovieRepo : RepositoryBase<Movie, MovieStoreDbContext>, IMovieRepo
    {
        public void SoftDelete(string Title)
        {
            using (var context=new MovieStoreDbContext())
            {
                var deleted = context.Movies.SingleOrDefault(x => x.Title==Title);
                deleted.IsActive = false;
                context.SaveChanges();
            }
        }

        public List<GetAllMoviesModel> GetAllMovieWithActors()
        {
            using (var context=new MovieStoreDbContext())
            {
                var movies = (from d in context.Directors
                              join m in context.Movies.Where(x => x.IsActive == true) on d.DirectorID equals m.DirectorId
                              select new GetAllMoviesModel
                              {
                                  Title = m.Title,
                                  PublishDate = m.PublishDate.Date.ToString("dd,MM,yyyy"),
                                  MovieGenre = ((GenreEnum)m.MovieGenre).ToString(),
                                  Price = m.Price,
                                  Director = $"{d.FirstName} {d.LastName}",
                                  Actors = m.Actors.Select(x => x.FirstName + " " + x.lastName).ToList()

                              }).ToList();
                return movies;
            }
        }




    }
}
