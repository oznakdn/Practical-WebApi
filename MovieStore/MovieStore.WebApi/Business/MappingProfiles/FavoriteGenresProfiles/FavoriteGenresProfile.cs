using AutoMapper;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.Enums;
using MovieStore.WebApi.Models.ViewModels.FavoriteGenresModels;

namespace MovieStore.WebApi.Business.MappingProfiles.FavoriteGenresProfiles
{
    public class FavoriteGenresProfile:Profile
    {
        public FavoriteGenresProfile()
        {
            CreateMap<CreateFavoriteGenresModel, FavoriteGenre>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src =>((GenreEnum) src.Genres)));
        }
    }
}
