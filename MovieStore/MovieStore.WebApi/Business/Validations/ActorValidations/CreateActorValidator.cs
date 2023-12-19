using FluentValidation;
using MovieStore.WebApi.Models.ViewModels.ActorViewModels;

namespace MovieStore.WebApi.Business.Validations.ActorValidations
{
    public class CreateActorValidator:AbstractValidator<CreateActorModel>
    {
        public CreateActorValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.lastName).NotNull().MinimumLength(2).MaximumLength(30);

        }
    }
}
