using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Abstract
{
    public interface IMovieService
    {
        Movie Add(Movie entity);
        Movie Update(Movie entity);
        List<Movie> GetAll(Expression<Func<Movie, bool>> Filter = null);
        Movie GetByFilter(Expression<Func<Movie, bool>> Filter);
        void SoftDelete(string Title);
        List<GetAllMoviesModel> GetAllMovieWithActors();
        GetAllMoviesModel GetMovieByTitle(string Title);
        void AddMovie(CreateMovieModel model);
        void UpdateMovie(UpdateMovieModel model, string Title);





    }
}
