using MovieStore.WebApi.Models.Enums;

namespace MovieStore.WebApi.Models.Entities
{
    public class FavoriteGenre
    {
        public int ID { get; set; }
        public GenreEnum Genre { get; set; }
        public int CustomerId { get; set; }

    }
}
