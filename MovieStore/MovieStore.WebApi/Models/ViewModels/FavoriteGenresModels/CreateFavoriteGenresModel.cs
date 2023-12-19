using MovieStore.WebApi.Models.Enums;

namespace MovieStore.WebApi.Models.ViewModels.FavoriteGenresModels
{
    public class CreateFavoriteGenresModel
    {
        public int Genres { get; set; }
        public int CustomerId { get; set; }
    }
}
