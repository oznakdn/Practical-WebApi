namespace BookStore.WebApi.Models.GenreModels
{
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }=true;
    }
}