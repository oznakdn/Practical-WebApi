using FluentValidation;
using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Models;
using SingerSong.Application.Helpers;
namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Validation;

public class InsertAlbumValidator : AbstractValidator<InsertAlbumRequest>
{
    public InsertAlbumValidator()
    {
        RuleFor(x => x.AlbumName).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Length(2, 20).WithMessage("{PropertyName} should be between 2 and 40 characters!");

        RuleFor(x => x.SongCount).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");

        RuleFor(x => x.SingerID).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");

    }

   
}

