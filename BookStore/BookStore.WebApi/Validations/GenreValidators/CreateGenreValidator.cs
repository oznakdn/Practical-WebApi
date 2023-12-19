using BookStore.WebApi.Models.GenreModels;
using FluentValidation;

namespace BookStore.WebApi.Validations.GenreValidators
{
    public class CreateGenreValidator:AbstractValidator<CreateGenreModel>
    {
        public CreateGenreValidator()
        {
            RuleFor(x=>x.Name).NotNull().MinimumLength(2).MaximumLength(20);
        }
    }
}