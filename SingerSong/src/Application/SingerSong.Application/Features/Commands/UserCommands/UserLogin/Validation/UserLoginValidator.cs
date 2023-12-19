using SingerSong.Application.Features.Commands.UserCommands.UserLogin.Models;

namespace SingerSong.Application.Features.Commands.UserCommands.UserLogin.Validation;

internal class UserLoginValidator:AbstractValidator<UserLoginRequest>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("{PropertyName} is required").EmailAddress().WithMessage("{PropertyName}'s format is wrong!");
        RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
    }
}

