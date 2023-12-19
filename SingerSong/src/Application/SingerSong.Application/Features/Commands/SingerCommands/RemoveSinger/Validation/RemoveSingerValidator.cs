using SingerSong.Application.Features.Commands.SingerCommands.RemoveSinger.Models;

namespace SingerSong.Application.Features.Commands.SingerCommands.RemoveSinger.Validation;

internal class RemoveSingerValidator : AbstractValidator<RemoveSingerRequest>
{
    public RemoveSingerValidator()
    {
        RuleFor(x => x.singerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");
    }
}

