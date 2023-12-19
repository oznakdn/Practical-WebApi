using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Models;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Validation;

internal class GetSingerAlbumSongsValidator:AbstractValidator<GetSingerAlbumSongsRequest>
{
    public GetSingerAlbumSongsValidator()
    {
        RuleFor(x => x.SingerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");
    }
}

