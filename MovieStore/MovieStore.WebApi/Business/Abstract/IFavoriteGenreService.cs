using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.FavoriteGenresModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Abstract
{
    public interface IFavoriteGenreService
    {
        FavoriteGenre Add(FavoriteGenre entity);
        FavoriteGenre Update(FavoriteGenre entity);
        List<FavoriteGenre> GetAll(Expression<Func<FavoriteGenre, bool>> Filter = null);
        FavoriteGenre GetByFilter(Expression<Func<FavoriteGenre, bool>> Filter);
        void AddFavoriteGenre(CreateFavoriteGenresModel model);
    }
}
