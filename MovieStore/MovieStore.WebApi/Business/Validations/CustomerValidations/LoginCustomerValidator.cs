using FluentValidation;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;

namespace MovieStore.WebApi.Business.Validations.CustomerValidations
{
    public class LoginCustomerValidator:AbstractValidator<LoginCustomerModel>
    {
        public LoginCustomerValidator()
        {
            RuleFor(x => x.Username).NotNull().MinimumLength(5).MaximumLength(10);
            RuleFor(x => x.Password).NotNull().MinimumLength(6).MaximumLength(6);
        }
    }
}
