using BookStore.WebApi.Models.GenreModels;
using FluentValidation;

namespace BookStore.WebApi.Validations.GenreValidators
{
    public class DeleteGenreValidator:AbstractValidator<DeleteGenreModel>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x=>x.Name).NotNull().MaximumLength(2).MaximumLength(20);
        }
    }
}