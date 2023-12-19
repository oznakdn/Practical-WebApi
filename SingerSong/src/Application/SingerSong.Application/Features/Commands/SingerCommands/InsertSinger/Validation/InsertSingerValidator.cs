using FluentValidation;
using SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Models;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Validation;

internal class InsertSingerValidator:AbstractValidator<InsertSingerRequest>
{
    public InsertSingerValidator()
    {
        RuleFor(x => x.SingerName).NotEmpty().NotNull().WithMessage("{PropertyName} is required").Length(2, 20).WithMessage("{PropertyName} should be between 2 and 20 characters!");

        RuleFor(x => x.Location).NotEmpty().NotNull().WithMessage("{PropertyName} is required").Length(2, 20).WithMessage("{PropertyName} should be between 2 and 20 characters!");
        RuleFor(x => x.MusicStyle).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
        RuleFor(x => x.SingerType).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
    }
}

