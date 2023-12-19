using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Concrete
{
    public class OrderRepo : RepositoryBase<Order, MovieStoreDbContext>, IOrderRepo
    {
        public void Delete(int id)
        {
            using (var context=new MovieStoreDbContext())
            {
                var query = context.Orders.Find(id);
                var deleted = context.Entry(query);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Order>GetAllOrder()
        {
            using (var context=new MovieStoreDbContext())
            {
                return context.Orders.Include(x => x.Movie).Include(y => y.Customer).ToList();
            }
        }
    }
}
