using MovieStore.WebApi.Models.Enums;

namespace MovieStore.WebApi.Models.ViewModels.CustomerViewModels
{
    public class CustomerFavoriteGenresModel
    {
        public string Fullname { get; set; }
        public List<string> Genre { get; set; }
    }
}
