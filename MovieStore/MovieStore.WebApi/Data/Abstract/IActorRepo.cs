using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Abstract
{
    public interface IActorRepo:IRepository<Actor>
    {
        void Delete(int Id);
    }
}
