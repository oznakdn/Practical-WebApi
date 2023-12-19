using BookStore.WebApi.Models.GenreModels;
using FluentValidation;

namespace BookStore.WebApi.Validations.GenreValidators
{
    public class UpdateGenreValidator:AbstractValidator<UpdateGenreModel>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x=>x.Name).NotNull().MinimumLength(2).MaximumLength(20);
        }
    }
}