namespace MovieStore.WebApi.Models.ViewModels.MovieViewModels
{
    public class GetAllMoviesModel
    {
        public string Title { get; set; }
        public string PublishDate { get; set; }
        public string MovieGenre { get; set; }
        public Decimal Price { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
    }
}
