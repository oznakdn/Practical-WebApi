using FluentValidation;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;

namespace MovieStore.WebApi.Business.Validations.MovieValidations
{
    public class UpdateMovieValidator:AbstractValidator<UpdateMovieModel>
    {
        public UpdateMovieValidator()
        {
            RuleFor(x => x.Title).NotNull().MinimumLength(2).MaximumLength(30);
            RuleFor(x => x.PublishDate).NotNull().LessThan(DateTime.Now);
            RuleFor(x => x.MovieGenre).NotNull().GreaterThan(0);
            RuleFor(x => x.Price).NotNull().GreaterThan(0);
            RuleFor(x => x.DirectorId).NotNull().GreaterThan(0);
        }
    }
}
