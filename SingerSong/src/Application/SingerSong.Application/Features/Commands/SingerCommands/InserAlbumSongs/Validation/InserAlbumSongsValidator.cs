using FluentValidation;
using SingerSong.Application.Features.Commands.SingerCommands.InserAlbumSongs.Models;
using SingerSong.Application.Helpers;

namespace SingerSong.Application.Features.Commands.SingerCommands.InserAlbumSongs.Validation;

internal class InserAlbumSongsValidator:AbstractValidator<InserAlbumSongsRequest>
{
    public InserAlbumSongsValidator()
    {
        RuleFor(x => x.AlbumId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");

        RuleFor(x => x.SingerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
           .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");
    }
}

