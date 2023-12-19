using AutoMapper;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.OrderViewModels;

namespace MovieStore.WebApi.Business.MappingProfiles.OrderProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderModel, Order>();

            CreateMap<Order, GetAllOrdersModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.Date.ToString("dd,MM,yyyy")));

            CreateMap<Order, GetOrdersByCustomerModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.Date.ToString("dd,MM,yyyy")));
        }
    }
}
