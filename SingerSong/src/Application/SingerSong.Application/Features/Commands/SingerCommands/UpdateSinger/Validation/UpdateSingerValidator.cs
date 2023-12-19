using SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Models;

namespace SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Validation;

internal class UpdateSingerValidator : AbstractValidator<UpdateSingerRequest>
{
    public UpdateSingerValidator()
    {
        RuleFor(x => x.SingerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");

        RuleFor(x => x.SingerName).NotEmpty().NotNull().WithMessage("{PropertyName} is required")
            .Length(2, 20).WithMessage("{PropertyName} should be between 2 and 20 characters!");

        RuleFor(x => x.Location).NotEmpty().NotNull().WithMessage("{PropertyName} is required")
            .Length(2, 20).WithMessage("{PropertyName} should be between 2 and 20 characters!");

        RuleFor(x => x.MusicStyle).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
        RuleFor(x => x.SingerType).NotEmpty().NotNull().WithMessage("{PropertyName} is required");

    }
}

