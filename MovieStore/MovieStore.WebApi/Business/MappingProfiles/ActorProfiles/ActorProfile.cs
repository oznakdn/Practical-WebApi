using AutoMapper;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.ActorViewModels;

namespace MovieStore.WebApi.Business.MappingProfiles.ActorProfiles
{
    public class ActorProfile:Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, GetAllActorsModel>();
            CreateMap<Actor, GetActorModel>();
            CreateMap<CreateActorModel, Actor>();

        }
    }
}
