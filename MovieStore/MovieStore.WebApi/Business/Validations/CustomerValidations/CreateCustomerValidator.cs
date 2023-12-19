using FluentValidation;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;

namespace MovieStore.WebApi.Business.Validations.CustomerValidations
{
    public class CreateCustomerValidator:AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.LastName).NotNull().MinimumLength(2).MaximumLength(30);
            RuleFor(x => x.Username).NotNull().MinimumLength(5).MaximumLength(10);
            RuleFor(x => x.Password).NotNull().MinimumLength(6).MaximumLength(6);


        }
    }
}
