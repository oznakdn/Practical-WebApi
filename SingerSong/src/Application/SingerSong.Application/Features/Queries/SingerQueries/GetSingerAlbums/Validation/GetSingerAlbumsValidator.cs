using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Models;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Validation;

internal class GetSingerAlbumsValidator : AbstractValidator<GetSingerAlbumsRequest>
{
    public GetSingerAlbumsValidator()
    {
        RuleFor(x => x.SingerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");
    }
}

