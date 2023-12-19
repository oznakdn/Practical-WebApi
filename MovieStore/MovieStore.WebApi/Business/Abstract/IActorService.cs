using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.ActorViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Abstract
{
    public interface IActorService
    {
        Actor Add(Actor entity);
        Actor Update(Actor entity);
        void Delete(int Id);

        List<Actor> GetAll(Expression<Func<Actor, bool>> Filter = null);
        Actor GetByFilter(Expression<Func<Actor, bool>> Filter);
        List<GetAllActorsModel> GetAllActors();
        GetActorModel GetActorById(int id);
        void AddActor(CreateActorModel model);
        void UpdateActor(UpdateActorModel model, int id);

    }
}
