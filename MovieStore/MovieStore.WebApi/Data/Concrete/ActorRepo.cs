using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Concrete
{
    public class ActorRepo : RepositoryBase<Actor, MovieStoreDbContext>, IActorRepo
    {
        public void Delete(int Id)
        {
            using (var context=new MovieStoreDbContext())
            {
                var findId = context.Actors.SingleOrDefault(x => x.ActorID == Id);
                var deleted = context.Entry(findId);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
                
            }
        }
    }
}
