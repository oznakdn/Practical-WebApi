using AutoMapper;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;

namespace MovieStore.WebApi.Business.MappingProfiles.CustomerProfiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, LoginCustomerModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<CreateCustomerModel, Customer>();

            CreateMap<Customer, GetAllCustomerModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<Customer, CustomerFavoriteGenresModel>()
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.FavoriteGenres.Select(x=>x.Genre.ToString())));
               



        }
    }
}
