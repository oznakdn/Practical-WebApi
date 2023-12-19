using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Concrete
{
    public class FavoriteGenreRepo:RepositoryBase<FavoriteGenre,MovieStoreDbContext>,IFavoriteGenreRepo
    {
    }
}
