using BookStore.WebApi.Models.GenreModels;
using FluentValidation;

namespace BookStore.WebApi.Validations.GenreValidators
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GenreDetailViewModel>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x=>x.Name).NotNull().MaximumLength(20).MinimumLength(2);
        }
    }
}