using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Concrete
{
    public class DirectorRepo : RepositoryBase<Director, MovieStoreDbContext>, IDirectorRepo
    {
        public void Delete(int id)
        {
            using (var context=new MovieStoreDbContext())
            {
                var deletedId = context.Directors.Find(id);
                var deleted = context.Entry(deletedId);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
