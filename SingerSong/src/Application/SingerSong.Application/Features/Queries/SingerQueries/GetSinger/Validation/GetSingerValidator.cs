using SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Models;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Validation;

internal class GetSingerValidator:AbstractValidator<GetSingerRequest>
{
    public GetSingerValidator()
    {
        RuleFor(x => x.singerId).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Must(ValidationHelpers.IsGuid).WithMessage("{PropertyName}'s format is wrong!");
    }
    
}

