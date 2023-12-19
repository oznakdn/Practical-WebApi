using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;

namespace MovieStore.WebApi.Data.Abstract
{
    public interface IMovieRepo:IRepository<Movie>
    {
        void SoftDelete(string Title);
        List<GetAllMoviesModel> GetAllMovieWithActors();
    }
}
