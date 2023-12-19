using SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Models;

namespace SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Validation;

internal class InsertAlbumsValidator:AbstractValidator<InsertAlbumsRequest>
{
    public InsertAlbumsValidator()
    {
        RuleFor(x=>x.SingerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");
        RuleFor(x=>x.albums.Select(x=>x.AlbumName).ToList()).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
    }
}


