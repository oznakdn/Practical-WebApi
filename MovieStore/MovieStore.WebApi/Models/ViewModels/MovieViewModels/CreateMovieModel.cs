namespace MovieStore.WebApi.Models.ViewModels.MovieViewModels
{
    public class CreateMovieModel
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int? MovieGenre { get; set; }
        public Decimal Price { get; set; }
        public int DirectorId { get; set; }

    }
}
