using AutoMapper;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.Enums;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;

namespace MovieStore.WebApi.Business.MappingProfiles.MovieProfiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieModel, Movie>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.MovieGenre))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DirectorId, opt => opt.MapFrom(src => src.DirectorId));
        }
    }
}
