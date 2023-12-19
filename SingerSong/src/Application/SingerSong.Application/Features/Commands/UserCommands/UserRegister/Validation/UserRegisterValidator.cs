using SingerSong.Application.Features.Commands.UserCommands.UserRegister.Models;

namespace SingerSong.Application.Features.Commands.UserCommands.UserRegister.Validation;

internal class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("{PropertyName} is required!")
            .Length(6, 30).WithMessage("{PropertyName} should be between 6 and 30 characters!")
            .EmailAddress().WithMessage("{PropertyName}'s format is wrong!");

        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("{PropertyName} is required!")
            .Length(6, 12).WithMessage("{PropertyName} should be between 6 and 12 characters!");
    }
}

