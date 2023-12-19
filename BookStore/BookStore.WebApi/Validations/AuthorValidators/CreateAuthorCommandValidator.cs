using BookStore.WebApi.Models.AuthorModels;
using FluentValidation;

namespace BookStore.WebApi.Validations.AuthorValidators
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorModel>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x=>x.FirstName).NotNull().MinimumLength(2).MaximumLength(20);
            RuleFor(x=>x.LastName).NotNull().MinimumLength(2).MaximumLength(30);
            RuleFor(x=>x.BirthDate).NotNull();

        }
    }
}