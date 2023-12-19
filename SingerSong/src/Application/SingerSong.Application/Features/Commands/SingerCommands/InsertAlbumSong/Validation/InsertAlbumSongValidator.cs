using FluentValidation;
using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Models;
using SingerSong.Application.Helpers;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Validation;

internal class InsertAlbumSongValidator : AbstractValidator<InsertAlbumSongRequest>
{
    public InsertAlbumSongValidator()
    {
        RuleFor(x => x.AlbumId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");

        RuleFor(x => x.SingerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
           .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");

        RuleFor(x => x.SongName).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
           .Length(2, 30).WithMessage("{PropertyName} field should be between 2 and 30 characters!");

        RuleFor(x => x.SongWeight).GreaterThan(0).WithMessage("{PropertyName} should be greater than zero!");

    }
}

