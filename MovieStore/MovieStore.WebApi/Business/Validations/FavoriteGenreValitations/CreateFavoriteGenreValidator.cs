using FluentValidation;
using MovieStore.WebApi.Models.Enums;
using MovieStore.WebApi.Models.ViewModels.FavoriteGenresModels;

namespace MovieStore.WebApi.Business.Validations.FavoriteGenreValitations
{
    public class CreateFavoriteGenreValidator:AbstractValidator<CreateFavoriteGenresModel>
    {
        public CreateFavoriteGenreValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.Genres).NotEmpty();

        }
    }
}
